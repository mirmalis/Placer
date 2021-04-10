using System;
using System.Collections.Generic;
using System.Linq;
using Placer.Seed.Reimplementations;

namespace Placer.Seed
{
  static class DND
  {
    public static DataStructure Data = new();
    public readonly static Scope Scope = new Scope("Dungeons & Dragons", Reality.Scope);
    internal readonly static Scope e5 = new Scope("5th edition", Scope);

    static DND()
    {
      CastingTimeUnits.AddData(Data);
      Durations.AddData(Data);
      Spells.AddData(Data);
      Books.AddData(Data);
      Conditions.AddData(Data);
    }
    static class Books
    {
      internal readonly static ThingDefinition Book = new(e5, "Book", 10, 15);
      public static readonly FieldDefinition atPage = new FieldDefinition("Page", Core.Value.DataType.Integer);
      public static readonly RelationDefinition inBook = new RelationDefinition(e5, "book", "spells")
        .AddFieldDefinition(atPage)
      ;
      internal readonly static Thing phb = new Idea(null, "phb").AddDefinition(Book);
      internal static void AddData(DataStructure dataStructure)
      {
        dataStructure.AddRange(phb);
      }
    }
    static class Durations
    {
      public static readonly ThingDefinition Duration = new ThingDefinition(e5, "Duration");
      public static readonly Thing Minutes = Reality.Minutes.AddDefinition(Duration);
      public static readonly Thing Hours = Reality.Hours.AddDefinition(Duration);
      public static readonly Thing Years = Reality.Years.AddDefinition(Duration);
      internal static void AddData(DataStructure dataStructure) =>
        dataStructure.AddRange(Minutes, Hours, Years);
    }
    static class CastingTimeUnits
    {
      public static readonly ThingDefinition CastingTimeUnit = new ThingDefinition(e5, "Casting Time Unit");
      public static readonly Thing Action = new Idea(e5, "Action").AddDefinition(CastingTimeUnit);
      public static readonly Thing BonusAction = new Idea(e5, "Bonus Action").AddDefinition(CastingTimeUnit);
      public static readonly Thing Reaction = new Idea(e5, "Reaction").AddDefinition(CastingTimeUnit);
      public static readonly Thing Minutes = Reality.Minutes.AddDefinition(CastingTimeUnit);
      public static readonly Thing Hours = Reality.Hours.AddDefinition(CastingTimeUnit);
      internal static void AddData(DataStructure dataStructure) =>
        dataStructure.AddRange(Action, BonusAction, Reaction, Minutes, Hours);
    }
    static class Conditions
    {
      public static ThingDefinition Condition = new ThingDefinition(e5, "Condition");
      public static Thing Darkness = Spells.darkness.AddDefinition(Condition);
      internal static void AddData(DataStructure dataStructure) =>
        dataStructure.AddRange(
          Darkness
        );
    }
    static class Spells
    {
      #region TypeDefintion
      public static FieldDefinition level = new FieldDefinition("Level", Core.Value.DataType.Integer);
      public static FieldDefinition ritual = new FieldDefinition("Ritual", Core.Value.DataType.Flag);
      public static FieldDefinition castingTimeUnitCount = new FieldDefinition("Count", Core.Value.DataType.Integer);
      public static RelationDefinition Spell_CastingTimeUnit = new RelationDefinition(e5, "Casting Time", "Spells")
        .AddFieldDefinition(castingTimeUnitCount)
        .AddFieldDefinition(ritual)
      ;
      #endregion
      public static ThingDefinition Spell = new ThingDefinition(e5, "Spell", 10, 10)
        .AddFieldDefinitions(level)
      ;
      #region Schools
      public static ThingDefinition School = new(e5, "School");
      public static Thing sch_Abjuration = new Idea(e5, "Abjuration").AddDefinition(School);
      public static Thing sch_Conjuration = new Idea(e5, "Conjuration").AddDefinition(School);
      public static Thing sch_Evocation = new Idea(e5, "Evocation").AddDefinition(School);
      public static Thing sch_Transmutation = new Idea(e5, "Transmutation").AddDefinition(School);
      public static RelationDefinition spell_school = new RelationDefinition(e5, "school", null);
      #endregion
      #region Instances
      static readonly Idea acidSplash = new Idea(Scope, "Acid Splash");
      static readonly Idea aid = new Idea(Scope, "Aid");
      static readonly Idea alarm = new Idea(Scope, "Alarm");
      static readonly Idea alterSelf = new Idea(Scope, "Alter Self");
      public static readonly Idea darkness = new Idea(Scope, "Darkness");
      #endregion
      static Spells()
      {
        acidSplash.AddDefinition(Spell)
          .AddRelationFrom(Books.inBook, Books.phb).LastRelationFrom.AddValue(Books.atPage, 211).From
          .AddValue(level, 0)
          .AddValue(ritual, false)
          .AddRelationFrom(spell_school, sch_Conjuration)
          .AddRelationFrom(Spell_CastingTimeUnit, CastingTimeUnits.Action).LastRelationFrom.AddValue(castingTimeUnitCount, 1)
        ;
        aid.AddDefinition(Spell)
          .AddValue(level, 2)
          .AddRelationFrom(spell_school, sch_Abjuration)
        ;
        alarm.AddDefinition(Spell)
          .AddValue(level, 1)
          .AddRelationFrom(spell_school, sch_Abjuration)
        ;
        alterSelf.AddDefinition(Spell)
          .AddValue(level, 1)
          .AddRelationFrom(spell_school, sch_Transmutation)
        ;
        darkness.AddDefinition(Spell)
          .AddValue(level, 2)
          .AddValue(ritual, false)
          .AddRelationFrom(spell_school, sch_Evocation)
          .AddRelationFrom(new RelationDefinition(e5, "causes", "is caused by"), Conditions.Darkness)
          .AddRelationFrom(Spell_CastingTimeUnit, CastingTimeUnits.Action).LastRelationFrom.AddValue(castingTimeUnitCount, 1)
        ;
      }
      internal static void AddData(DataStructure dataStructure) =>
        dataStructure.AddRange(acidSplash, aid, alarm, alterSelf);
    }
  }
}