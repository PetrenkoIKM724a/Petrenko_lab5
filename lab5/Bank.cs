using System;

public class Bank
{
    private string _name;
    private decimal _totalAssets;

    public string Name
    {
        get { return _name; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Назва банку не може бути порожньою.");
            _name = value;
        }
    }

    public decimal TotalAssets
    {
        get { return _totalAssets; }
        private set
        {
            if (value < 0)
                throw new ArgumentException("Активи банку не можуть бути від'ємними.");
            _totalAssets = value;
        }
    }

    public string SwiftCode { get; set; }

    public Bank(string name, string swiftCode, decimal initialAssets)
    {
        Name = name;
        SwiftCode = swiftCode;
        TotalAssets = initialAssets;
    }

    public void AddAssets(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Сума для поповнення активів має бути більшою за нуль.");

        TotalAssets += amount;
    }

    public override string ToString()
    {
        return $"Банк: {Name} | SWIFT: {SwiftCode} | Загальні активи: {TotalAssets:C}";
    }

    public override bool Equals(object obj)
    {
        if (obj is Bank otherBank)
        {
            return this.SwiftCode == otherBank.SwiftCode;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(SwiftCode);
    }
}