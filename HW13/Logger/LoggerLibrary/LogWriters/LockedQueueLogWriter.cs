using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace Logger
{
    public class LockedQueuetLogWriter : GuardedLogWriter
    {
        protected Queue<string> WriteQueue = new Queue<string>();
        protected AutoResetEvent QueueBecameNonEmpty = new AutoResetEvent(true);
        protected AutoResetEvent QueueIsFlushed = new AutoResetEvent(false);
        protected Thread WriteThreadHandle { get; }
        protected bool Disposing { get; set; } = false;

        public LockedQueuetLogWriter() { }

        public LockedQueuetLogWriter(TextWriter writer)
            : base(writer)
        {
            WriteThreadHandle = new Thread(new ThreadStart(WriteMethod));
            WriteThreadHandle.Start();
        }

        protected void WriteMethod()
        {
            while (true)
            {
                QueueBecameNonEmpty.WaitOne(1000);
                string line;
                lock (this)
                {
                    while ((line = WriteQueue.Dequeue()) != null)
                        Writer.WriteLine(line);
                }
                Writer.Flush();

                if (this.Disposing)
                {
                    Writer.Dispose();
                    QueueIsFlushed.Set();
                    return;
                }
            }
        }
        public override void Dispose()
        {
            this.Disposing = true;
            QueueBecameNonEmpty.Set();
            if (!QueueIsFlushed.WaitOne(1000))
                throw new TimeoutException("Queue not flushed after 1 second");
        }

        public override void WriteLine(string line)
        {
            lock (this)
            {
                WriteQueue.Enqueue(line);
                QueueBecameNonEmpty.Set();
            }
        }

        public override GuardedLogWriter CreateInstance(TextWriter writer)
            => new ConcurrentLogWriter(writer);
    }
}
