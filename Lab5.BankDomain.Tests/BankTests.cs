using System;
using Xunit;

public class BankTests
{
    [Fact]
    public void Constructor_ValidData_CreatesBankObject()
    {
        var bank = new Bank("ПриватБанк", "PB12345", 1500000m);

        Assert.Equal("ПриватБанк", bank.Name);
        Assert.Equal("PB12345", bank.SwiftCode);
        Assert.Equal(1500000m, bank.TotalAssets);
    }

    [Fact]
    public void Constructor_EmptyName_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => new Bank("", "SWIFTCODE", 1000m));
    }

    [Fact]
    public void Constructor_NegativeAssets_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => new Bank("Ощадбанк", "OSH123", -500m));
    }

    [Fact]
    public void AddAssets_ValidAmount_IncreasesTotalAssets()
    {
        var bank = new Bank("Монобанк", "MONO001", 5000m);

        bank.AddAssets(2500m);

        Assert.Equal(7500m, bank.TotalAssets);
    }

    [Fact]
    public void AddAssets_NegativeAmount_ThrowsArgumentException()
    {
        var bank = new Bank("Укрсиббанк", "UKR002", 5000m);

        Assert.Throws<ArgumentException>(() => bank.AddAssets(-100m));
    }

    [Fact]
    public void Equals_SameSwiftCode_ReturnsTrue()
    {
        var bank1 = new Bank("Банк А", "SAME_SWIFT", 1000m);
        var bank2 = new Bank("Банк Б", "SAME_SWIFT", 2000m);

        bool areEqual = bank1.Equals(bank2);

        Assert.True(areEqual);
    }
}