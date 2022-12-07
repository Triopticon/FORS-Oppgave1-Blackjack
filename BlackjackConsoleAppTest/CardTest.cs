namespace BlackjackConsoleAppTest;

[TestClass]
public class CardTest
{
    [TestMethod]
    public void TestClassConstructorWithRandomText()
    {
        // Arrange
        string suit = "TestSuit";
        string value = "TestValue";

        //Act
        Card card = new Card(Suit: suit, Value: value);

        // Assert
        Assert.AreEqual(suit, card.Suit, $"Card Suite should have the value '{suit}'!");
        Assert.AreEqual(value, card.Value, $"Card Value should have the value '{value}'!");
        Assert.AreEqual(0, card.Number, "Card number should be '0'!");
    }

    [TestMethod]
    public void TestClassConstructorWithRealCardInfo()
    {
        // Arrange
        var suit = "HEARTS";
        var value = "2";

        //Act
        Card card = new Card(Suit: suit, Value: value);

        // Assert
        Assert.AreEqual(suit, card.Suit, $"Card Suite should have the value '{suit}'!");
        Assert.AreEqual(value, card.Value, $"Card Value should have the value '{value}'!");
        Assert.AreEqual(2, card.Number, "Card number should be '2'!");
    }

    [TestMethod]
    public void TestClassConstructorWithValueNotAsNumber()
    {
        // Arrange
        var suit = "HEARTS";
        var value = "J";

        //Act
        Card card = new Card(Suit: suit, Value: value);

        // Assert
        Assert.AreEqual(suit, card.Suit, $"Card Suite should have the value '{suit}'!");
        Assert.AreEqual(value, card.Value, $"Card Value should have the value '{value}'!");
        Assert.AreEqual(10, card.Number, "Card number should be '10'!");
    }

    [TestMethod]
    public void TestGetCardNumberMethod()
    {
        // Arrange
        int number = 2;
        string suit = "HEARTS";
        string value = number.ToString();

        Card card = new Card(Suit: suit, Value: value);


        //Act
        int numberFromCard = Card.GetCardNumber(value);

        // Assert
        Assert.AreEqual(number, card.Number, $"Card number should be '{number}'!");
        Assert.AreEqual(number, numberFromCard, $"Card number should be '{number}'!");
        Assert.AreEqual(card.Number, numberFromCard, $"Card number should be '{number}'!");
    }
}
