﻿// Copyright (c) Microsoft. All rights reserved.

using System.Text.Json;

namespace Microsoft.TypeChat.Tests;

public enum Coffees
{
    [Comment("Drip coffee")]
    Coffee,
    Latte,
    Mocha,
    [Comment("For all other coffee types")]
    Unknown,
}

public enum CoffeeSize
{
    Small,
    Medium,
    Large,
    Grande,
    Venti
}

[Comment("Orders for coffee only")]
public class CoffeeOrder
{
    [JsonPropertyName("coffee")]
    public Coffees Coffee { get; set; }
    [JsonPropertyName("quantity")]
    public int Quantity { get; set; }
    [JsonPropertyName("size")]
    public CoffeeSize Size { get; set; }
}

public class Creamer
{
    [JsonVocab(Name = TestVocabs.Names.Creamers)]
    public string Name { get; set; }
}

public class Milk
{
    [JsonVocab(Name = TestVocabs.Names.Milks, Inline = true)]
    [JsonPropertyName("name")]
    public string Name { get; set; }
}

public class DessertOrder
{
    [JsonVocab(Name = TestVocabs.Names.Desserts)]
    [JsonPropertyName("dessert")]
    public string Name { get; set; }
    [JsonPropertyName("quantity")]
    public int Quantity { get; set; }
}

public class FruitOrder
{
    [JsonVocab(Name = TestVocabs.Names.Fruits)]
    [JsonPropertyName("fruit")]
    public string Name { get; set; }
    [JsonPropertyName("quantity")]
    public int Quantity { get; set; }
}

public class Order
{
    [JsonPropertyName("coffee")]
    public CoffeeOrder[] Coffees { get; set; }
    [JsonPropertyName("desserts")]
    public DessertOrder[] Desserts { get; set; }
    [JsonPropertyName("fruits")]
    public FruitOrder[] Fruits { get; set; }
}

public class SentimentResponse
{
    [JsonPropertyName("sentiment")]
    public string Sentiment { get; set; }
}

public class NullableTestObj
{
    public CoffeeSize Required;
    public CoffeeSize? Optional;
    public string Text;

    [JsonPropertyName("optionalText")]
    public string? OptionalText { get; set; }

    public string? OptionalTextField { get; set; }

    public int Amt;
    public int? OptionalAmt;
}

public class WrapperNullableObj
{
    public NullableTestObj? Test { get; set; }

    [JsonVocab(Name = TestVocabs.Names.Milks, Inline = true)]
    [JsonPropertyName("milk")]
    public string? OptionalMilk { get; set; }
}

public class ConverterTestObj
{
    [JsonVocab("Whole | Two Percent | Almond | Soy")]
    public string Milk { get; set; }
}

public class LocalVocabObj
{
    public const string VocabName = "Local";

    [JsonVocab("One | Two | Three | Four", Name = VocabName)]
    public string Value { get; set; }
}

public class JsonFunc
{
    public string Name { get; set; }
}

public class JsonExpr
{
    public JsonFunc Func;
    public JsonElement Value;
}

public static class TestVocabs
{
    public static class Names
    {
        public const string Desserts = "Desserts";
        public const string Fruits = "Fruits";
        public const string Milks = "Milks";
        public const string Creamers = "Creamers";
    }

    public static VocabCollection All()
    {
        return new VocabCollection
        {
            Desserts(),
            Fruits(),
            Milks(),
            Creamers()
        };
    }

    public static VocabType Desserts()
    {
        Vocab vocab = new Vocab
        {
            "Tiramisu",
            "Strawberry Cake",
            "Banana Cake",
            "Coffee Cake",
            "Strawberry Shortcake",
            "Chocolate Cake"
        };
        return new VocabType(Names.Desserts, vocab);
    }

    public static VocabType Fruits()
    {
        Vocab vocab = new Vocab
        {
            "Regular Apple",
            "Honeycrisp Apple",
            "Banana",
            "Rainier Cherry",
            "Blackberry",
            "Pear",
            "Nectarine"
        };

        return new VocabType(Names.Fruits, vocab);
    }

    public static VocabType Milks()
    {
        Vocab vocab = new Vocab
        {
            "whole milk",
            "two percent milk",
            "nonfat milk",
            "coconut milk",
            "soy milk",
            "almond milk",
            "oat milk"
        };
        return new VocabType(Names.Milks, vocab);
    }

    public static VocabType Creamers()
    {
        Vocab vocab = new Vocab
        {
            "whole milk creamer",
            "two percent milk creamer",
            "one percent milk creamer",
            "nonfat milk creamer",
            "coconut milk creamer",
            "soy milk creamer",
            "almond milk creamer",
            "oat milk creamer",
            "half and half",
            "heavy cream"
        };
        return new VocabType(Names.Creamers, vocab);
    }
}
