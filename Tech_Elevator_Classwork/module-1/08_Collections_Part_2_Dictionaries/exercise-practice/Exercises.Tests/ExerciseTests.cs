using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Collections.Generic;

namespace Exercises.Tests
{
    [TestClass]
    public class ExerciseTests
    {
        Exercises exercises = new Exercises();
        const double DoubleAllowableDifference = 0.001;

        [TestMethod]
        public void Exercise01_AnimalGroupName()
        {
            Assert.AreEqual("Tower", exercises.AnimalGroupName("giraffe"), "Input: animalGroupName(\"giraffe\")");
            Assert.AreEqual("unknown", exercises.AnimalGroupName(""), "Input: animalGroupName(\"\")");
            Assert.AreEqual("unknown", exercises.AnimalGroupName("walrus"), "Input: animalGroupName(\"walrus\")");
            Assert.AreEqual("Crash", exercises.AnimalGroupName("Rhino"), "Input: animalGroupName(\"Rhino\")");
            Assert.AreEqual("Crash", exercises.AnimalGroupName("rhino"), "Input: animalGroupName(\"rhino\")");
            Assert.AreEqual("unknown", exercises.AnimalGroupName("elephants"), "Input: animalGroupName(\"elephants\")");
            Assert.AreEqual("unknown", exercises.AnimalGroupName(null), "Input: animalGroupName(null)");
        }

        [TestMethod]
        public void Exercise02_IsItOnSale()
        {
            Assert.AreEqual(0.20, exercises.IsItOnSale("kitchen4001"), DoubleAllowableDifference, "Input: isItOnSale(\"kitchen4001\")");
            Assert.AreEqual(0.00, exercises.IsItOnSale(""), DoubleAllowableDifference, "Input: isItOnSale(\"\")");
            Assert.AreEqual(0.15, exercises.IsItOnSale("GARAGE1070"), DoubleAllowableDifference, "Input: isItOnSale(\"GARAGE1070\")");
            Assert.AreEqual(0.00, exercises.IsItOnSale("dungeon9999"), DoubleAllowableDifference, "Input: isItOnSale(\"dungeon9999\")");
            Assert.AreEqual(0.00, exercises.IsItOnSale(null), DoubleAllowableDifference, "Input: isItOnSale(null)");
        }

        [TestMethod]
        public void Exercise03_RobPeterToPayPaul()
        {
            Dictionary<string, int> expected = peterPaulInput(1000, 1099);
            Dictionary<string, int> actual = exercises.RobPeterToPayPaul(peterPaulInput(2000, 99));

            AssertCollections(expected, actual, "Input: RobPeterToPayPaul(new Dictionary<string, int>() { \"Peter\": 2000, \"Paul\": 99 })");

            expected = peterPaulInput(2000, 30000);
            actual = exercises.RobPeterToPayPaul(peterPaulInput(2000, 30000));

            AssertCollections(expected, actual, "Input: RobPeterToPayPaul(new Dictionary<string, int>() { \"Peter\": 2000, \"Paul\": 30000 })");

            expected = peterPaulInput(0, 5000);
            actual = exercises.RobPeterToPayPaul(peterPaulInput(0, 5000));

            AssertCollections(expected, actual, "Input: RobPeterToPayPaul(new Dictionary<string, int>() { \"Peter\": 0, \"Paul\": 5000 })");

            expected = peterPaulInput(1, 5000);
            actual = exercises.RobPeterToPayPaul(peterPaulInput(1, 5000));

            AssertCollections(expected, actual, "Input: RobPeterToPayPaul(new Dictionary<string, int>() { \"Peter\": 1, \"Paul\": 5000 })");

            expected = peterPaulInput(1173, 1672);
            actual = exercises.RobPeterToPayPaul(peterPaulInput(2345, 500));

            AssertCollections(expected, actual, "Input: RobPeterToPayPaul(new Dictionary<string, int>() { \"Peter\": 2345, \"Paul\": 500 })");

            expected = peterPaulInput(5000, 1000);
            actual = exercises.RobPeterToPayPaul(peterPaulInput(5000, 1000));

            AssertCollections(expected, actual, "Input: RobPeterToPayPaul(new Dictionary<string, int>() { \"Peter\": 5000, \"Paul\": 1000 })");

            expected = peterPaulInput(2500, 3499);
            actual = exercises.RobPeterToPayPaul(peterPaulInput(5000, 999));

            AssertCollections(expected, actual, "Input: RobPeterToPayPaul(new Dictionary<string, int>() { \"Peter\": 5000, \"Paul\": 999 })");
        }

        private Dictionary<string, int> peterPaulInput(int peterMoney, int paulMoney)
        {
            Dictionary<string, int> input = new Dictionary<string, int>();
            input.Add("Peter", peterMoney);
            input.Add("Paul", paulMoney);
            return input;
        }

        [TestMethod]
        public void Exercise04_PeterPaulPartnership()
        {
            Dictionary<string, int> expected = new Dictionary<string, int>()
            {
                {"Peter", 37500 },
                {"Paul", 75000 },
                {"PeterPaulPartnership", 37500 }
            };
            Dictionary<string, int> actual = exercises.PeterPaulPartnership(new Dictionary<string, int>()
            {
                {"Peter", 50000 },
                {"Paul", 100000 }
            });

            AssertCollections(expected, actual, "Input: PeterPaulPartnership(new Dictionary<string, int>() { \"Peter\": 50000, \"Paul\": 100000 })");

            expected = new Dictionary<string, int>()
            {
                {"Peter", 3333 },
                {"Paul", 1234567890 }
            };

            actual = exercises.PeterPaulPartnership(new Dictionary<string, int>()
            {
                {"Peter", 3333 },
                {"Paul", 1234567890 }
            });

            AssertCollections(expected, actual, "Input: PeterPaulPartnership(new Dictionary<string, int>() { \"Peter\": 3333, \"Paul\": 1234567890 })");
        }

        [TestMethod]
        public void Exercise05_BeginningAndEnding()
        {
            Dictionary<string, string> expected = new Dictionary<string, string>()
            {
                { "b", "g" },
                { "c", "e" }
            };
            Dictionary<string, string> actual = exercises.BeginningAndEnding(new string[] { "code", "bug" });
            AssertCollections(expected, actual, "Input: BeginningAndEnding(new string[] { \"code\", \"bug\" })");

            expected = new Dictionary<string, string>()
            {
                { "b", "g" },
                { "c", "t" }
            };
            actual = exercises.BeginningAndEnding(new string[] { "code", "bug", "cat" });
            AssertCollections(expected, actual, "Input: BeginningAndEnding(new string[] { \"code\", \"bug\", \"cat\" })");

            expected = new Dictionary<string, string>()
            {
                { "m", "n" },
            };
            actual = exercises.BeginningAndEnding(new string[] { "man", "moon", "main" });
            AssertCollections(expected, actual, "Input: BeginningAndEnding(new string[] { \"man\", \"moon\", \"main\" })");


            expected = new Dictionary<string, string>()
            {
                { "g","d" },
                { "m", "t" },
                { "n", "t" }
            };
            actual = exercises.BeginningAndEnding(new string[] { "muddy", "good", "moat", "good", "night" });
            AssertCollections(expected, actual, "Input: BeginningAndEnding(new string[] { \"muddy\", \"good\", \"moat\", \"good\", \"night\" })");
        }

        [TestMethod]
        public void Exercise06_WordCount()
        {
            Dictionary<string, int> expected = new Dictionary<string, int>()
            {
                {"ba", 2 },
                {"black", 1 },
                {"sheep", 1 }
            };
            Dictionary<string, int> actual = exercises.WordCount(new string[] { "ba", "ba", "black", "sheep" });
            AssertCollections(expected, actual, "Input: WordCount(new string[] { \"ba\", \"ba\", \"black\", \"sheep\" })");

            expected = new Dictionary<string, int>()
            {
                {"ba", 4 },
                {"black", 2 },
                {"sheep", 2 }
            };
            actual = exercises.WordCount(new string[] { "ba", "ba", "black", "sheep", "ba", "ba", "black", "sheep" });
            AssertCollections(expected, actual, "Input: WordCount(new string[] { \"ba\", \"ba\", \"black\", \"sheep\", \"ba\", \"ba\", \"black\", \"sheep\" })");

            expected = new Dictionary<string, int>()
            {
                {"b", 2 },
                {"c", 1 },
                {"a", 2 }
            };
            actual = exercises.WordCount(new string[] { "a", "b", "a", "c", "b" });
            AssertCollections(expected, actual, "Input: WordCount(new string[] { \"a\", \"b\", \"a\", \"c\", \"b\" })");

            expected = new Dictionary<string, int>()
            {
            };
            actual = exercises.WordCount(new string[] { });
            AssertCollections(expected, actual, "Input: WordCount(new string[] { })");

            expected = new Dictionary<string, int>()
            {
                {"b", 1 },
                {"c", 1 },
                {"a", 1 }
            };
            actual = exercises.WordCount(new string[] { "c", "b", "a" });
            AssertCollections(expected, actual, "Input: WordCount(new string[] { \"c\", \"b\", \"a\" })");

            expected = new Dictionary<string, int>()
            {
                {"apple", 4 },
                {"banana", 3 },
                {"carrot", 1 },
                {"dill", 2 }
            };
            actual = exercises.WordCount(new string[] { "apple", "apple", "banana", "apple", "carrot", "banana", "dill", "dill", "banana", "apple" });
            AssertCollections(expected, actual, "Input: WordCount(new string[] { \"apple\", \"apple\", \"banana\", \"apple\", \"carrot\", \"banana\", \"dill\", \"dill\", \"banana\", \"apple\" }");

            expected = new Dictionary<string, int>()
            {
                {"apple", 6 }
            };
            actual = exercises.WordCount(new string[] { "apple", "apple", "apple", "apple", "apple", "apple" });
            AssertCollections(expected, actual, "Input: WordCount(new string[] { \"apple\", \"apple\", \"apple\", \"apple\", \"apple\", \"apple\" })");
        }

        [TestMethod]
        public void Exercise07_IntCount()
        {
            Dictionary<int, int> expected = new Dictionary<int, int>()
            {
                {1, 2 },
                {44, 1 },
                {55, 1 },
                {63, 3 },
                {77, 1 },
                {99, 2 }
            };
            Dictionary<int, int> actual = exercises.IntCount(new int[] { 1, 99, 63, 1, 55, 77, 63, 99, 63, 44 });
            AssertCollections(expected, actual, "Input: IntCount(new int[] { 1, 99, 63, 1, 55, 77, 63, 99, 63, 44 })");

            expected = new Dictionary<int, int>()
            {
                {33, 4 },
                {106, 1 },
                {107, 3 }
            };
            actual = exercises.IntCount(new int[] { 107, 33, 107, 33, 33, 33, 106, 107 });
            AssertCollections(expected, actual, "Input: IntCount(new int[] { 107, 33, 107, 33, 33, 33, 106, 107 })");

            expected = new Dictionary<int, int>()
            {
            };
            actual = exercises.IntCount(new int[] { });
            AssertCollections(expected, actual, "Input: IntCount(new int[] { })");
        }

        [TestMethod]
        public void Exercise08_WordMultiple()
        {
            Dictionary<string, bool> expected = new Dictionary<string, bool>()
            {
                {"b", true },
                {"c", false },
                {"a", true }
            };
            Dictionary<string, bool> actual = exercises.WordMultiple(new string[] { "a", "b", "a", "c", "b" });
            AssertCollections(expected, actual, "Input: WordMultiple(new string[] { \"a\", \"b\", \"a\", \"c\", \"b\" })");

            expected = new Dictionary<string, bool>()
            {
                { "b", false },
                { "c", false },
                { "a", false }
            };
            actual = exercises.WordMultiple(new string[] { "c", "b", "a" });
            AssertCollections(expected, actual, "Input: WordMultiple(new string[] { \"c\", \"b\", \"a\" })");

            expected = new Dictionary<string, bool>()
            {
                { "c", true }
            };
            actual = exercises.WordMultiple(new string[] { "c", "c", "c", "c" });
            AssertCollections(expected, actual, "Input: WordMultiple(new string[] { \"c\", \"c\", \"c\", \"c\" })");

        }

        [TestMethod]
        public void Exercise09_ConsolidateInventory()
        {
            Dictionary<string, int> expected = new Dictionary<string, int>()
            {
                {"SKU1", 100 },
                {"SKU2", 64 },
                {"SKU3", 44 },
                {"SKU4", 5 }
            };
            Dictionary<string, int> actual = exercises.ConsolidateInventory(new Dictionary<string, int>()
            {
                {"SKU1", 100 },
                {"SKU2", 53 },
                {"SKU3", 44 }
            }, new Dictionary<string, int>()
            {
                {"SKU2", 11 },
                {"SKU4", 5 }
            });
            AssertCollections(expected, actual, "Input: ConsolidateInventory(new Dictionary<string, int>() {{ \"SKU1\", 100 }, { \"SKU2\", 53 }, { \"SKU3\", 44 }}, new Dictionary<string, int>() {{ \"SKU2\", 11 }, { \"SKU4\", 5 }})");

            expected = new Dictionary<string, int>()
            {
                {"SKU_4", 68 },
                {"SKU_23", 86 },
                {"SKU_39", 66 },
                {"SKU_50", 444 },
                {"SKU_X", 9 }
            };
            actual = exercises.ConsolidateInventory(new Dictionary<string, int>()
            {
                {"SKU_4", 0 },
                {"SKU_23", 53 },
                {"SKU_39", 66 },
                {"SKU_X", 8 }
            }, new Dictionary<string, int>()
            {
                {"SKU_4", 68 },
                {"SKU_23", 33 },
                {"SKU_50", 444 },
                {"SKU_X", 1 }
            });
            AssertCollections(expected, actual, "Input: ConsolidateInventory(new Dictionary<string, int>() {{ \"SKU_4\", 0 }, { \"SKU_23\", 53 }, { \"SKU_39\", 66 }, { \"SKU_X\", 8 }}, new Dictionary<string, int>() {{ \"SKU_4\", 68 }, { \"SKU_23\", 33 }, { \"SKU_50\", 444 }, { \"SKU_X\", 1 }})");

            expected = new Dictionary<string, int>()
            {
                {"Lorem", 11 },
                {"Ipsum", 22 },
                {"Dolor", 33 },
                {"Sit", 44 },
                {"Amet", 55 }
            };
            actual = exercises.ConsolidateInventory(new Dictionary<string, int>()
            {
                {"Lorem", 11 },
                {"Ipsum", 22 },
                {"Dolor", 33 },
                {"Sit", 44 },
                {"Amet", 55 }
            }, new Dictionary<string, int>()
            {
            });
            AssertCollections(expected, actual, "Input: ConsolidateInventory(new Dictionary<string, int>() {{ \"Lorem\", 11 }, { \"Ipsum\", 22 }, { \"Dolor\", 33 }, { \"Sit\", 44 }, { \"Amet\", 55 }}, new Dictionary<string, int>() { })");

            expected = new Dictionary<string, int>()
            {
                {"Lorem", 66 },
                {"Ipsum", 77 },
                {"Dolor", 88 },
                {"Sit", 99 },
                {"Amet", 111 }
            };
            actual = exercises.ConsolidateInventory(new Dictionary<string, int>()
            {

            }, new Dictionary<string, int>()
            {
                {"Lorem", 66 },
                {"Ipsum", 77 },
                {"Dolor", 88 },
                {"Sit", 99 },
                {"Amet", 111 }
            });
            AssertCollections(expected, actual, "Input: ConsolidateInventory(new Dictionary<string, int>() { }, new Dictionary<string, int>() {{ \"Lorem\", 66 }, { \"Ipsum\", 77 }, { \"Dolor\", 88 }, { \"Sit\", 99 }, { \"Amet\", 111 }})");
        }

        [TestMethod]
        public void Exercise10_Last2Revisited()
        {
            Dictionary<string, int> expected = new Dictionary<string, int>()
            {
                {"hixxhi", 1 },
                {"xaxxaxaxx", 1 },
                {"axxxaaxx", 2 }
            };
            Dictionary<string, int> actual = exercises.Last2Revisited(new string[] { "hixxhi", "xaxxaxaxx", "axxxaaxx" });
            AssertCollections(expected, actual, "Input: Last2Revisited(new string[] { \"hixxhi\", \"xaxxaxaxx\", \"axxxaaxx\" })");

            expected = new Dictionary<string, int>()
            {
                {"banana", 1 },
                {"kiwi", 0 },
                {"Hahahahaha", 3 }
            };
            actual = exercises.Last2Revisited(new string[] { "banana", "kiwi", "Hahahahaha" });
            AssertCollections(expected, actual, "Input: Last2Revisited(new string[] { \"banana\", \"kiwi\", \"Hahahahaha\" })");

        }

        // No Such dictionary collection assert exists so we needed to write our own
        private void AssertCollections(Dictionary<string, int> expected, Dictionary<string, int> actual, string message)
        {
            if (actual == null)
            {
                Assert.Fail($"Output from method is null. {message}");
            }

            foreach (KeyValuePair<string, int> kvp in expected)
            {
                if (!actual.ContainsKey(kvp.Key))
                {
                    Assert.Fail($"Output from method doesn't contain expected key: {kvp.Key}. {message}");
                }
                Assert.AreEqual(kvp.Value, actual[kvp.Key], message);
            }
        }

        private void AssertCollections(Dictionary<string, string> expected, Dictionary<string, string> actual, string message)
        {
            if (actual == null)
            {
                Assert.Fail($"Output from method is null. {message}");
            }

            foreach (KeyValuePair<string, string> kvp in expected)
            {
                if (!actual.ContainsKey(kvp.Key))
                {
                    Assert.Fail($"Output from method doesn't contain expected key: {kvp.Key}. {message}");
                }
                Assert.AreEqual(kvp.Value, actual[kvp.Key], message);
            }
        }

        private void AssertCollections(Dictionary<string, bool> expected, Dictionary<string, bool> actual, string message)
        {
            if (actual == null)
            {
                Assert.Fail($"Output from method is null. {message}");
            }

            foreach (KeyValuePair<string, bool> kvp in expected)
            {
                if (!actual.ContainsKey(kvp.Key))
                {
                    Assert.Fail($"Output from method doesn't contain expected key: {kvp.Key}. {message}");
                }
                Assert.AreEqual(kvp.Value, actual[kvp.Key], message);
            }
        }

        private void AssertCollections(Dictionary<int, int> expected, Dictionary<int, int> actual, string message)
        {
            if (actual == null)
            {
                Assert.Fail($"Output from method is null. {message}");
            }

            foreach (KeyValuePair<int, int> kvp in expected)
            {
                if (!actual.ContainsKey(kvp.Key))
                {
                    Assert.Fail($"Output from method doesn't contain expected key: {kvp.Key}. {message}");
                }
                Assert.AreEqual(kvp.Value, actual[kvp.Key], message);
            }
        }
    }
}
