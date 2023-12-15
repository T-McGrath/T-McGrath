using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercises.Tests
{
    [TestClass]
    public class ValidationTests
    {
        private const int SmallCheese = 10;
        private const int SmallPepperoni = 11;

        private const int MediumCheese = 20;
        private const int MediumPepperoni = 21;

        private const int LargeCheese = 30;
        private const int LargePepperoni = 31;

        private const int Calzone = 40;
        private const int SpaghettiPie = 41;
        private const int BakedZiti = 42;

        private const char SmallShirt = 'S';
        private const char MediumShirt = 'M';
        private const char LargeShirt = 'L';

        [TestMethod]
        public void Exercise01_01_CreateOrder()
        {
            Exercise01_StoreOrders exercises01 = new Exercise01_StoreOrders();

            CollectionAssert.AreEqual(new int[] { SmallCheese, Calzone, LargePepperoni, SpaghettiPie }, exercises01.CreateOrder(), "CreateOrder()");
        }


        [TestMethod]
        public void Exercise01_02_GetCalzoneSales()
        {
            Exercise01_StoreOrders exercises01 = new Exercise01_StoreOrders();

            Assert.AreEqual(2, exercises01.GetCalzoneSales(new int[] { Calzone, SmallCheese, LargeCheese, Calzone, SmallCheese }),
                                                    "GetCalzoneSales([Calzone, SmallCheese, LargeCheese, Calzone, SmallCheese])");

            Assert.AreEqual(0, exercises01.GetCalzoneSales(new int[] { SmallCheese, SmallPepperoni, SmallCheese }),
                                                    "GetCalzoneSales([SmallCheese, SmallPepperoni, SmallCheese])");

            Assert.AreEqual(0, exercises01.GetCalzoneSales(new int[] { SmallPepperoni, BakedZiti }),
                                                  "GetCalzoneSales([SmallPepperoni, BakedZiti])");

            Assert.AreEqual(0, exercises01.GetCalzoneSales(new int[] { }), "GetCalzoneSales([])");

            Assert.AreEqual(1, exercises01.GetCalzoneSales(new int[] { Calzone, SmallCheese, SmallCheese }),
                                                    "GetCalzoneSales([Calzone, SmallCheese, SmallCheese])");

            Assert.AreEqual(1, exercises01.GetCalzoneSales(new int[] { SmallCheese, Calzone, SmallCheese }),
                                                    "GetCalzoneSales([SmallCheese, Calzone, SmallCheese])");

            Assert.AreEqual(1, exercises01.GetCalzoneSales(new int[] { SmallCheese, SmallCheese, Calzone }),
                                                    "GetCalzoneSales([SmallCheese, SmallCheese, Calzone])");

            Assert.AreEqual(1, exercises01.GetCalzoneSales(new int[] { BakedZiti, SmallCheese, Calzone, SpaghettiPie }),
                                        "GetCalzoneSales([BakedZiti, SmallCheese, Calzone, SpaghettiPie])");

            Assert.AreEqual(2, exercises01.GetCalzoneSales(new int[] { Calzone, Calzone, SmallCheese }),
                                                    "GetCalzoneSales([Calzone, Calzone, SmallCheese])");

            Assert.AreEqual(3, exercises01.GetCalzoneSales(new int[] { Calzone, Calzone, Calzone }),
                                                    "GetCalzoneSales([Calzone, Calzone, Calzone])");
        }


        [TestMethod]
        public void Exercise01_03_GetCheesePizzaRevenue()
        {
            Exercise01_StoreOrders exercises01 = new Exercise01_StoreOrders();

            Assert.AreEqual(8, exercises01.GetCheesePizzaRevenue(new int[] { SmallCheese }),
                                                     "GetCheesePizzaRevenue([SmallCheese])");

            Assert.AreEqual(11, exercises01.GetCheesePizzaRevenue(new int[] { MediumCheese }),
                                                      "GetCheesePizzaRevenue([MediumCheese])");

            Assert.AreEqual(14, exercises01.GetCheesePizzaRevenue(new int[] { LargeCheese }),
                                                      "GetCheesePizzaRevenue([LargeCheese])");

            Assert.AreEqual(19, exercises01.GetCheesePizzaRevenue(new int[] { SmallCheese, SmallPepperoni, MediumCheese }),
                                                      "GetCheesePizzaRevenue([SmallCheese, SmallPepperoni, MediumCheese])");

            Assert.AreEqual(33, exercises01.GetCheesePizzaRevenue(new int[] { SmallCheese, SmallPepperoni, MediumCheese, SmallPepperoni, LargeCheese }),
                                                      "GetCheesePizzaRevenue([SmallCheese, SmallPepperoni, MediumCheese, SmallPepperoni, LargeCheese])");

            Assert.AreEqual(25, exercises01.GetCheesePizzaRevenue(new int[] { MediumCheese, SmallPepperoni, LargeCheese }),
                                                      "GetCheesePizzaRevenue([MediumCheese, SmallPepperoni, LargeCheese])");

            Assert.AreEqual(14, exercises01.GetCheesePizzaRevenue(new int[] { BakedZiti, LargeCheese }),
                                                      "GetCheesePizzaRevenue([BakedZiti, LargeCheese])");

            Assert.AreEqual(0, exercises01.GetCheesePizzaRevenue(new int[] { SmallPepperoni, MediumPepperoni, LargePepperoni }),
                                                     "GetCheesePizzaRevenue([SmallPepperoni, MediumPepperoni, LargePepperoni])");

            Assert.AreEqual(0, exercises01.GetCheesePizzaRevenue(new int[] { BakedZiti, SpaghettiPie }),
                                         "GetCheesePizzaRevenue([BakedZiti, SpaghettiPie])");
        }
        

        [TestMethod]
        public void Exercise02_01_GenerateSeatingChart()
        {
            Exercise02_BoardingGate exercises02 = new Exercise02_BoardingGate();

            CollectionAssert.AreEqual(new bool[] { },
                exercises02.GenerateSeatingChart(0),
                           "GenerateSeatingChart(0)");

            CollectionAssert.AreEqual(new bool[] { true },
                exercises02.GenerateSeatingChart(1),
                           "GenerateSeatingChart(1)");

            CollectionAssert.AreEqual(new bool[] { true, true },
                exercises02.GenerateSeatingChart(2),
                           "GenerateSeatingChart(2)");

            CollectionAssert.AreEqual(new bool[] { true, true, true },
                exercises02.GenerateSeatingChart(3),
                           "GenerateSeatingChart(3)");

            CollectionAssert.AreEqual(new bool[] { true, true, true, true },
                exercises02.GenerateSeatingChart(4),
                           "GenerateSeatingChart(4)");

            CollectionAssert.AreEqual(new bool[] { true, true, true, true, true },
                exercises02.GenerateSeatingChart(5),
                           "GenerateSeatingChart(5)");
        }


        [TestMethod]
        public void Exercise02_02_GetAvailableSeatCount()
        {
            Exercise02_BoardingGate exercises02 = new Exercise02_BoardingGate();

            Assert.AreEqual(0, exercises02.GetAvailableSeatCount(new bool[] { }),
                                                      "GetAvailableSeatCount([])");

            Assert.AreEqual(1, exercises02.GetAvailableSeatCount(new bool[] { true }),
                                                      "GetAvailableSeatCount([true])");

            Assert.AreEqual(0, exercises02.GetAvailableSeatCount(new bool[] { false }),
                                                      "GetAvailableSeatCount([false])");

            Assert.AreEqual(0, exercises02.GetAvailableSeatCount(new bool[] { false, false, false, false, false, false }),
                                                      "GetAvailableSeatCount([false, false, false, false, false, false])");

            Assert.AreEqual(1, exercises02.GetAvailableSeatCount(new bool[] { true, false, false, false }),
                                                      "GetAvailableSeatCount([true, false, false, false])");

            Assert.AreEqual(2, exercises02.GetAvailableSeatCount(new bool[] { true, false, true, false }),
                                                      "GetAvailableSeatCount([true, false, true, false])");

            Assert.AreEqual(2, exercises02.GetAvailableSeatCount(new bool[] { false, true, true, false }),
                                                      "GetAvailableSeatCount([false, true, true, false])");

            Assert.AreEqual(2, exercises02.GetAvailableSeatCount(new bool[] { false, false, true, true, }),
                                                      "GetAvailableSeatCount([false, false, true, true,])");

            Assert.AreEqual(3, exercises02.GetAvailableSeatCount(new bool[] { true, true, true, false }),
                                                      "GetAvailableSeatCount([true, true, true, false])");

            Assert.AreEqual(3, exercises02.GetAvailableSeatCount(new bool[] { true, true, false, true }),
                                                      "GetAvailableSeatCount([true, true, false, true])");

            Assert.AreEqual(3, exercises02.GetAvailableSeatCount(new bool[] { true, false, true, true }),
                                                      "GetAvailableSeatCount([true, false, true, true])");

            Assert.AreEqual(3, exercises02.GetAvailableSeatCount(new bool[] { false, true, true, true }),
                                                      "GetAvailableSeatCount([false, true, true, true])");
        }


        [TestMethod]
        public void Exercise02_03_GetNumberOfFullRows()
        {
            Exercise02_BoardingGate exercises02 = new Exercise02_BoardingGate();

            Assert.AreEqual(0, exercises02.GetNumberOfFullRows(new bool[] { }),
                                                      "GetNumberOfFullRows([])");

            Assert.AreEqual(2, exercises02.GetNumberOfFullRows(new bool[] { false, false, false, false, false, false }),
                                                      "GetNumberOfFullRows([false, false, false, false, false, false])");

            Assert.AreEqual(1, exercises02.GetNumberOfFullRows(new bool[] { false, false, false }),
                                                      "GetNumberOfFullRows([false, false, false])");



            Assert.AreEqual(1, exercises02.GetNumberOfFullRows(new bool[] { false, false, false, true, true, true }),
                                                      "GetNumberOfFullRows([false, false, false, true, true, true])");

            Assert.AreEqual(0, exercises02.GetNumberOfFullRows(new bool[] { true, true, true, true, true, true }),
                                                      "GetNumberOfFullRows([true, true, true, true, true, true])");

            Assert.AreEqual(0, exercises02.GetNumberOfFullRows(new bool[] { false, true, true, false, true, true }),
                                                      "GetNumberOfFullRows([false, true, true, false, true, true])");

            Assert.AreEqual(0, exercises02.GetNumberOfFullRows(new bool[] { true, false, true, true, false, true }),
                                                      "GetNumberOfFullRows([true, false, true, true, false, true])");

            Assert.AreEqual(0, exercises02.GetNumberOfFullRows(new bool[] { true, true, false, true, true, false }),
                                                      "GetNumberOfFullRows([true, true, false, true, true, false])");

            Assert.AreEqual(0, exercises02.GetNumberOfFullRows(new bool[] { true, false, true, false, true, false }),
                                                      "GetNumberOfFullRows([true, false, true, false, true, false])");
        }


        [TestMethod]
        public void Exercise03_01_BuildOrder()
        {
            Exercise03_Shirts exercises03 = new Exercise03_Shirts();

            CollectionAssert.AreEqual(new char[] { SmallShirt, SmallShirt, SmallShirt, MediumShirt, MediumShirt, LargeShirt },
                exercises03.BuildOrder(),
                           "BuildOrder()");
        }


        [TestMethod]
        public void Exercise03_02_BuildBulkOrder()
        {
            Exercise03_Shirts exercises03 = new Exercise03_Shirts();

            CollectionAssert.AreEqual(new char[] { },
                exercises03.BuildBulkOrder(0),
                           "BuildBulkOrder(0)");

            CollectionAssert.AreEqual(new char[] { SmallShirt },
                exercises03.BuildBulkOrder(1),
                           "BuildBulkOrder(1)");

            CollectionAssert.AreEqual(new char[] { SmallShirt, MediumShirt },
                exercises03.BuildBulkOrder(2),
                           "BuildBulkOrder(2)");

            CollectionAssert.AreEqual(new char[] { SmallShirt, MediumShirt, LargeShirt },
                exercises03.BuildBulkOrder(3),
                           "BuildBulkOrder(3)");

            CollectionAssert.AreEqual(new char[] { SmallShirt, MediumShirt, LargeShirt, SmallShirt },
                exercises03.BuildBulkOrder(4),
                           "BuildBulkOrder(4)");

            CollectionAssert.AreEqual(new char[] { SmallShirt, MediumShirt, LargeShirt, SmallShirt, MediumShirt },
                exercises03.BuildBulkOrder(5),
                           "BuildBulkOrder(5)");

            CollectionAssert.AreEqual(new char[] { SmallShirt, MediumShirt, LargeShirt, SmallShirt, MediumShirt, LargeShirt },
                exercises03.BuildBulkOrder(6),
                           "BuildBulkOrder(6)");
        }


        [TestMethod]
        public void Exercise03_03_PlaceRequest()
        {
            Exercise03_Shirts exercises03 = new Exercise03_Shirts();

            Assert.IsFalse(exercises03.PlaceRequest(new char[] { }),
                                               "$PlaceRequest([])");

            Assert.IsTrue(exercises03.PlaceRequest(new char[] { SmallShirt }),
                                             $"PlaceRequest(['{SmallShirt}'])");

            Assert.IsFalse(exercises03.PlaceRequest(new char[] { MediumShirt }),
                                             $"PlaceRequest(['{MediumShirt}'])");

            Assert.IsFalse(exercises03.PlaceRequest(new char[] { LargeShirt }),
                                             $"PlaceRequest(['{LargeShirt}'])");

            Assert.IsTrue(exercises03.PlaceRequest(new char[] { SmallShirt, MediumShirt, LargeShirt }),
                                             $"PlaceRequest(['{SmallShirt}', '{MediumShirt}', '{LargeShirt}'])");

            Assert.IsTrue(exercises03.PlaceRequest(new char[] { MediumShirt, SmallShirt, LargeShirt }),
                                             $"PlaceRequest(['{MediumShirt}', '{SmallShirt}', '{LargeShirt}'])");

            Assert.IsFalse(exercises03.PlaceRequest(new char[] { MediumShirt, LargeShirt }),
                                             $"PlaceRequest(['{MediumShirt}', '{LargeShirt}'])");

            Assert.IsTrue(exercises03.PlaceRequest(new char[] { MediumShirt, LargeShirt, SmallShirt }),
                                             $"PlaceRequest(['{MediumShirt}', '{LargeShirt}', '{SmallShirt}'])");

            Assert.IsFalse(exercises03.PlaceRequest(new char[] { MediumShirt, MediumShirt, LargeShirt }),
                                             $"PlaceRequest(['{MediumShirt}', '{MediumShirt}', '{LargeShirt}'])");
        }


        [TestMethod]
        public void Exercise04_01_FirstCard()
        {
            Exercise04_Cards exercises04 = new Exercise04_Cards();

            Assert.AreEqual("3-H", exercises04.GetFirstCard(new string[] { "3-H", "7-H", "5-H", "8-H", "6-H" }),
                                                            "GetFirstCard(\"3-H\", \"7-H\", \"5-H\", \"8-H\", \"6-H\")");

            Assert.AreEqual("1-C", exercises04.GetFirstCard(new string[] { "1-C", "1-D", "1-H", "1-S", "2-C" }),
                                                            "GetFirstCard(\"1-C\", \"1-D\", \"1-H\", \"1-S\", \"2-C\")");

            Assert.AreEqual("K-C", exercises04.GetFirstCard(new string[] { "K-C", "Q-D", "J-H", "10-S", "Q-C" }),
                                                            "GetFirstCard(\"K-C\", \"Q-D\", \"J-H\", \"10-S\", \"Q-C\")");
        }


        [TestMethod]
        public void Exercise04_02_DiscardFirstCard()
        {
            Exercise04_Cards exercises04 = new Exercise04_Cards();

            CollectionAssert.AreEqual(new string[] { "7-H", "5-H", "8-H", "6-H" },
                exercises04.DiscardFirstCard(new string[] { "3-H", "7-H", "5-H", "8-H", "6-H" }),
                                            "DiscardFirstCard([\"3-H\", \"7-H\", \"5-H\", \"8-H\", \"6-H\"])");
            CollectionAssert.AreEqual(new string[] { "1-D", "1-H", "1-S", "2-C" },
                exercises04.DiscardFirstCard(new string[] { "1-C", "1-D", "1-H", "1-S", "2-C" }),
                                            "DiscardFirstCard([\"1-C\", \"1-D\", \"1-H\", \"1-S\", \"2-C\"])");
            CollectionAssert.AreEqual(new string[] { "Q-D", "J-H", "10-S", "Q-C" },
                exercises04.DiscardFirstCard(new string[] { "K-C", "Q-D", "J-H", "10-S", "Q-C" }),
                                            "DiscardFirstCard([\"K-C\", \"Q-D\", \"J-H\", \"10-S\", \"Q-C\"])");
        }

        [TestMethod]
        public void Exercise04_03_DiscardTopCard()
        {
            Exercise04_Cards exercises04 = new Exercise04_Cards();

            CollectionAssert.AreEqual(new string[] { "10-H", "J-C", "8-D", "6-S", "Q-C", "2-D" },
                exercises04.DiscardTopCard(new string[] { "8-D", "10-H", "J-C", "8-D", "6-S", "Q-C", "2-D" }),
                                            "DiscardTopCard([\"8-D\", \"10-H\", \"J-C\", \"8-D\", \"6-S\", \"Q-C\", \"2-D\"])");
            CollectionAssert.AreEqual(new string[] { "6-S", "K-D" },
                exercises04.DiscardTopCard(new string[] { "4-D", "6-S", "K-D" }),
                                            "DiscardTopCard([\"4-D\", \"6-S\", \"K-D\"])");
            CollectionAssert.AreEqual(new string[] { },
                exercises04.DiscardTopCard(new string[] { "9-H" }),
                                            "DiscardTopCard([\"9-H\"])");
            CollectionAssert.AreEqual(new string[] { },
                exercises04.DiscardTopCard(new string[] { }),
                                            "DiscardTopCard([])");
        }


        [TestMethod]
        public void Exercise05_01_BelowFreezing()
        {
            Exercise05_Weather exercises05 = new Exercise05_Weather();

            Assert.AreEqual(7, exercises05.BelowFreezing(new int[] { 32, 31, 30, 29, 30, 31, 32 }),
                                                    "BelowFreezing([32, 31, 30, 29, 30, 31, 32])");

            Assert.AreEqual(3, exercises05.BelowFreezing(new int[] { 33, 30, 37, 32, 38, 31, 36 }),
                                                    "BelowFreezing([33, 30, 37, 32, 38, 31, 36])");

            Assert.AreEqual(0, exercises05.BelowFreezing(new int[] { 33, 43, 55, 37, 44, 52, 34 }),
                                                    "BelowFreezing([33, 43, 55, 37, 44, 52, 34])");

            Assert.AreEqual(4, exercises05.BelowFreezing(new int[] { -7, -3, 19, 35, 30 }),
                                                    "BelowFreezing([-7, -3, 19, 35, 30])");

            Assert.AreEqual(4, exercises05.BelowFreezing(new int[] { 33, -7, 31, -3, 34, 32 }),
                                                    "BelowFreezing([33, -7, 31, -3, 34, 32])");

            Assert.AreEqual(1, exercises05.BelowFreezing(new int[] { 33, -11 }),
                                                    "BelowFreezing([33, -11])");

            Assert.AreEqual(1, exercises05.BelowFreezing(new int[] { 32, 33 }),
                                                    "BelowFreezing([32, 33])");

            Assert.AreEqual(0, exercises05.BelowFreezing(new int[] { }),
                                                    "BelowFreezing([])");
        }


        [TestMethod]
        public void Exercise05_02_HottestDay()
        {
            Exercise05_Weather exercises05 = new Exercise05_Weather();

            Assert.AreEqual(105, exercises05.HottestDay(new int[] { 81, 93, 94, 105, 99, 95, 101, 90, 89, 92 }),
                                                      "HottestDay([81, 93, 94, 105, 99, 95, 101, 90, 89, 92])");

            Assert.AreEqual(-2, exercises05.HottestDay(new int[] { -7, -2, -11, -9, -4 }),
                                                     "HottestDay([-7, -2, -11, -9, -4])");

            Assert.AreEqual(24, exercises05.HottestDay(new int[] { 23, 24 }),
                                                     "HottestDay([23, 24])");

            Assert.AreEqual(34, exercises05.HottestDay(new int[] { 34, 33 }),
                                                     "HottestDay([34, 33])");

            Assert.AreEqual(55, exercises05.HottestDay(new int[] { 55 }),
                                                     "HottestDay([55])");

            Assert.AreEqual(-22, exercises05.HottestDay(new int[] { -22 }),
                                                      "HottestDay([-22])");
        }


        [TestMethod]
        public void Exercise05_03_FixTemperatures()
        {
            Exercise05_Weather exercises05 = new Exercise05_Weather();

            CollectionAssert.AreEqual(new int[] { 35, 30, 34, 37, 46, 31, 43 },
                exercises05.FixTemperatures(new int[] { 33, 30, 32, 37, 44, 31, 41 }),
                                     "FixTemperatures([33, 30, 32, 37, 44, 31, 41])");

            CollectionAssert.AreEqual(new int[] { -5, -33, 21, 35 },
                exercises05.FixTemperatures(new int[] { -7, -33, 19, 35 }),
                                     "FixTemperatures([-7, -33, 19, 35])");

            CollectionAssert.AreEqual(new int[] { 1, 0, 3 },
                exercises05.FixTemperatures(new int[] { -1, 0, 1 }),
                                     "FixTemperatures([-1, 0, 1])");

            CollectionAssert.AreEqual(new int[] { 1 },
                exercises05.FixTemperatures(new int[] { -1 }),
                                     "FixTemperatures([-1])");

            CollectionAssert.AreEqual(new int[] { },
                exercises05.FixTemperatures(new int[] { }),
                                     "FixTemperatures([])");
        }
    }
}
