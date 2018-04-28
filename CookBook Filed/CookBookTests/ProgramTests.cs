using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assignment5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Assignment5.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        
        [TestMethod()]
        public void NewRecipeGetTest()
        {
            string TestTitle = "Testtitle";
            string TestInstructions = "Testinstruct";
            string TestCuisine = "Testcuisine";
            string[] TestKeywords = new string[] { "Test1", "Test2" ,"?" };
            int TestServingCount = 4;
            int TestInCount = 1;

            Recipe TestRecipe = new Recipe(TestTitle, TestInstructions, TestInCount, TestServingCount, TestCuisine, TestKeywords);
            using (StreamWriter writer = new StreamWriter(@"XTest.txt"))
            {
                writer.WriteLine("A");
                writer.WriteLine(TestRecipe.Title);
                writer.WriteLine(TestRecipe.Instructions);
                writer.WriteLine(TestRecipe.Cuisine);
                writer.WriteLine(TestRecipe.ServingCount.ToString());
                writer.WriteLine(String.Join(" ", TestRecipe.KeyWords));
                writer.WriteLine(TestRecipe.IngredientCount);
            }
            using (StreamReader reader = new StreamReader(@"XTest.txt"))
            {
                Console.SetIn(reader);
                Recipe Subject = Program.NewRecipeGet(true);
                Assert.AreEqual(Subject.Title,TestRecipe.Title);
                Assert.AreEqual(Subject.Cuisine, TestRecipe.Cuisine);
                Assert.AreEqual(Subject.ServingCount, TestRecipe.ServingCount);
                CollectionAssert.AreEqual(Subject.KeyWords, TestRecipe.KeyWords);
                Assert.AreEqual(Subject.Instructions, TestRecipe.Instructions);
                Assert.AreEqual(Subject.IngredientCount, TestRecipe.IngredientCount);

            }



        }

        [TestMethod()]
        public void LoadCaseSaveCaseTest ()
        {
            var DifOut = Console.Out;
            var DifIn = Console.In;
            try
            {
                RecipeBook TestBook = new RecipeBook("TestTitle", 20);

                using (StringWriter writer = new StringWriter())
                {
                    Console.SetOut(writer);
                    Program.SaveCase(TestBook);
                    Assert.IsTrue(File.Exists(Recipe.RecipeFileAddress));
                    string res = writer.GetStringBuilder().ToString();
                    Assert.AreEqual(res, "Successfully Saved\r\n");
                }
                using (StringWriter writer = new StringWriter())
                {
                    Console.SetOut(writer);
                    if (File.Exists(Recipe.RecipeFileAddress))
                    {
                        Program.LoadCase(TestBook);
                        Assert.IsTrue(File.Exists(Recipe.RecipeFileAddress));
                        string res = writer.GetStringBuilder().ToString();
                        Assert.AreEqual(res, "Seccessfully Loaded\r\n");
                    }



                }
            }
            finally
            {
                Console.SetIn(DifIn);
                Console.SetOut(DifOut);
            }

        }
        [TestMethod()]
        public void SearchCasesAndListTest ()
        {
            var DifOut = Console.Out;
            var DifIn = Console.In;
            try
            {
                RecipeBook TestBook = new RecipeBook("TestTitle", 20);
                //Recipe Test 1
                string TestTitle = "TestTitle1";
                string TestInstructions = "TestInstruction1";
                string TestCuisine = "TestCuisine1";
                string[] TestKeywords = new string[] { "Test1", "Test2" };
                int TestServingCount = 2;
                int TestInCount = 5;
                Recipe TestRecipe = new Recipe(TestTitle, TestInstructions, TestInCount, TestServingCount, TestCuisine, TestKeywords);
                TestBook.Add(TestRecipe);

                //Recipe Test 2
                string TestTitle2 = "TestTitle2";
                string TestInstructions2 = "TestInstruction2";
                string TestCuisine2 = "TestCuisine2";
                string[] TestKeywords2 = new string[] { "Test3", "Test4" };
                int TestServingCount2 = 2;
                int TestInCount2 = 5;
                Recipe TestRecipe2 = new Recipe(TestTitle2, TestInstructions2, TestInCount2, TestServingCount2, TestCuisine2, TestKeywords2);
                TestBook.Add(TestRecipe2);

                // Recipe Test 3
                string TestTitle3 = "TestTitle3";
                string TestInstructions3 = "TestInstruction3";
                string TestCuisine3 = "TestCuisine3";
                string[] TestKeywords3 = new string[] { "Test5", "Test6" };
                int TestServingCount3 = 2;
                int TestInCount3 = 5;
                Recipe TestRecipe3 = new Recipe(TestTitle3, TestInstructions3, TestInCount3, TestServingCount3, TestCuisine3, TestKeywords3);
                TestBook.Add(TestRecipe3);

                //Keyword search
                string CharacterTest1 = "Test2\n1";
                using (StringReader reader = new StringReader(CharacterTest1))
                using (StringWriter writer = new StringWriter())
                {
                    Console.SetIn(reader);
                    Console.SetOut(writer);
                    Program.KeywordSearchCase(TestBook);
                    string res = writer.GetStringBuilder().ToString();
                    string expected = "Enter the Keyword :\r\n1. TestTitle1\r\n\nSelect recipe : \r\n\r\n Title : TestTitle1\n Instructions : TestInstruction1\n Cuisine : TestCuisine1\n Serving Count : 2 \n Ingredients Count : 0\n\r\n";
                    Assert.AreEqual(res,expected);
                }
                //Cuisine search
                string CharacterTest2 = "TestCuisine2\n1";
                using (StringReader reader = new StringReader(CharacterTest2))
                using (StringWriter writer = new StringWriter())
                {
                    Console.SetIn(reader);
                    Console.SetOut(writer);
                    Program.CuisineSearchCase(TestBook);
                    string res = writer.GetStringBuilder().ToString();
                    string expected = "Enter the Cuisine :\r\n1. TestTitle2\r\n\nSelect recipe : \r\n\r\n Title : TestTitle2\n Instructions : TestInstruction2\n Cuisine : TestCuisine2\n Serving Count : 2 \n Ingredients Count : 0\n\r\n";
                    Assert.AreEqual(res, expected);
                }
                //Title search
                string CharacterTest3 = "TestTitle3\n1";
                using (StringReader reader = new StringReader(CharacterTest3))
                using (StringWriter writer = new StringWriter())
                {
                    Console.SetIn(reader);
                    Console.SetOut(writer);
                    Program.TitleSearchCase(TestBook);
                    string res = writer.GetStringBuilder().ToString();
                    string expected = "Enter the Title :\r\n1. TestTitle3\r\nPress any key to show the recipe !\r\n\r\n Title : TestTitle3\n Instructions : TestInstruction3\n Cuisine : TestCuisine3\n Serving Count : 2 \n Ingredients Count : 0\n\r\n";
                    Assert.AreEqual(res, expected);
                }

                //List Test
                string CharacterTest4 = "A\n2";
                using (StringReader reader = new StringReader(CharacterTest4))
                using (StringWriter writer = new StringWriter())
                {
                    Console.SetIn(reader);
                    Console.SetOut(writer);
                    Program.ListCase(TestBook);
                    string res = writer.GetStringBuilder().ToString();
                    string expected = "List Recipes\r\nPress any key to continue !\r\n1. TestTitle1\r\n2. TestTitle2\r\n3. TestTitle3\r\n\nSelect recipe : \r\n\r\n Title : TestTitle2\n Instructions : TestInstruction2\n Cuisine : TestCuisine2\n Serving Count : 2 \n Ingredients Count : 0\n\r\n";
                    Assert.AreEqual(res, expected);
                }

            }
            finally
            {
                Console.SetIn(DifIn);
                Console.SetOut(DifOut);
            }
        }
        [TestMethod()]
        public void DeleteTest ()
        {
            var DifOut = Console.Out;
            var DifIn = Console.In;

            try
            {
                RecipeBook TestBook = new RecipeBook("TestTitle", 20);
                string TestTitle = "Test";
                string TestInstructions = "Test";
                string TestCuisine = "Test";
                string[] TestKeywords = new string[] { "Test1", "Test2" };
                int TestServingCount = 2;
                int TestInCount = 5;
                Recipe TestRecipe = new Recipe(TestTitle, TestInstructions, TestInCount, TestServingCount, TestCuisine, TestKeywords);
                TestBook.Add(TestRecipe);
                string CharacterTest = "A\nTest";
                using (StringReader reader = new StringReader(CharacterTest))
                using (StringWriter writer = new StringWriter())
                {
                    Console.SetIn(reader);
                    Console.SetOut(writer);
                    Program.DeleteCase(TestBook);
                    string res = writer.GetStringBuilder().ToString();
                    string expected = "Delete Recipe\r\nPress any key to continue !\r\nPlease enter the name of your recipe\r\nRecipe successfully removed !\r\n";
                    Assert.AreEqual(res,expected);
                }
            }
            finally
            {
                Console.SetIn(DifIn);
                Console.SetOut(DifOut);
            }
        }
        [TestMethod()]
        public void SearchInitTest ()
        {
            var DifOut = Console.Out;
            var DifIn = Console.In;
            try
            {
                string CharacterTest = "a";
                using (StringReader reader = new StringReader(CharacterTest))
                using (StringWriter writer = new StringWriter())
                {
                    Console.SetIn(reader);
                    Console.SetOut(writer);
                    Program.SearchInit();
                    string res = writer.GetStringBuilder().ToString();
                    string expected = "Search Recipe\r\nPress any key to continue !\r\n\r\nHow do you want to search for recipe ?\r\nSearch by (T)itle\r\nSearch by (K)eyword\r\nSearch by (C)uisine\r\n";
                    Assert.AreEqual(res, expected);
                }
            }
            finally
            {
                Console.SetIn(DifIn);
                Console.SetOut(DifOut);
            }
        }
        [TestMethod()]
        public void PauseTest()
        {
            string s = "T";
            using (StringReader Reader = new StringReader(s))
            using (StringWriter Writer = new StringWriter())
            {
                Console.SetOut(Writer);
                Console.SetIn(Reader);
                Program.Pause();
                string result = Writer.ToString();
                result = result.Remove(result.IndexOf('!'));
                Assert.AreEqual(result, "Press any key to continue ");
            }
        }
        [TestMethod()]
        public void SuccessMessageTest()
        {
            string TT = "Recipe successfully added !";
            string TF = "Recipe successfully removed !";
            string FT = "Failed to add your Recipe !!";
            string FF = "Failed to remove your Recipe !";

            Assert.AreEqual(Program.SuccessMessage(true, true), TT);
            Assert.AreEqual(Program.SuccessMessage(false, true), FT);
            Assert.AreEqual(Program.SuccessMessage(true, false),TF);
            Assert.AreEqual(Program.SuccessMessage(false, false), FF);

        }
        [TestMethod()]
        public void CaseYTest ()
        {
            var DifOut = Console.Out;
            var DifIn = Console.In;
            try
            {
                string CharacterTest = "1";
                using (StringReader reader = new StringReader(CharacterTest))
                using (StringWriter writer = new StringWriter())
                {
                    Console.SetIn(reader);
                    Console.SetOut(writer);
                    Program.CaseY(true);
                    string res = writer.GetStringBuilder().ToString();
                    string expected = "Please enter number of ingredients for this recipe :\r\n";
                    Assert.AreEqual(res, expected);
                }
            }
            finally
            {
                Console.SetIn(DifIn);
                Console.SetOut(DifOut);
            }
        }
        [TestMethod()]
        public void CaseNTest ()
        {
            var DifOut = Console.Out;
            var DifIn = Console.In;
            try
            {
                string CharacterTest = "3";
                using (StringReader reader = new StringReader(CharacterTest))
                using (StringWriter writer = new StringWriter())
                {
                    Console.SetIn(reader);
                    Console.SetOut(writer);
                    Assert.AreEqual(3, Program.CaseN());
                    string res = writer.GetStringBuilder().ToString();
                    string expected = "\r\nPlease enter number of ingredients for this recipe\r\n";
                    Assert.AreEqual(res, expected);
                    
                }
            }
            finally
            {
                Console.SetIn(DifIn);
                Console.SetOut(DifOut);
            }
        }


    }
}