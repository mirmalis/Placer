using System;
using System.Collections.Generic;
using System.Linq;
using Placer.Seed.Reimplementations;

namespace Placer.Seed
{
  static class DND
  {
    public static DataStructure Data = new();
    public readonly static Scope Scope = new Scope("Dungeons & Dragons", null);
    internal readonly static Scope e5 = new Scope("5th edition", Scope);

    static DND()
    {
      CastingTimeUnits.AddData(Data);
      Durations.AddData(Data);
      Spells.AddData(Data);
      Books.AddData(Data);
    }
    static class Books
    {
      internal readonly static ThingDefinition Book = new(Scope, "book");
      public static readonly FieldDefinition atPage = new FieldDefinition("page", Core.Value.DataType.Integer);
      public static readonly RelationDefinition inBook = new RelationDefinition("book", "spells")
        .AddFieldDefinition(atPage)
      ;
      internal readonly static Thing phb = new Idea("phb").AddDefinition(Book);
      internal static void AddData(DataStructure dataStructure)
      {
        dataStructure.AddRange(phb);
      }
    }
    static class Durations
    {
      public static readonly ThingDefinition Duration = new ThingDefinition(e5, "Duration");
      public static readonly Thing Minutes = TimeUnits.Minutes.AddDefinition(Duration);
      public static readonly Thing Hours = TimeUnits.Hours.AddDefinition(Duration);
      public static readonly Thing Years = TimeUnits.Years.AddDefinition(Duration);
      internal static void AddData(DataStructure dataStructure) =>
        dataStructure.AddRange(Minutes, Hours, Years);
    }
    static class CastingTimeUnits
    {
      public static readonly ThingDefinition CastingTimeUnit = new ThingDefinition(e5, "Casting Time Unit");
      public static readonly Thing Action = new Idea("Action").AddDefinition(CastingTimeUnit);
      public static readonly Thing BonusAction = new Idea("Bonus Action").AddDefinition(CastingTimeUnit);
      public static readonly Thing Reaction = new Idea("Reaction").AddDefinition(CastingTimeUnit);
      public static readonly Thing Minutes = TimeUnits.Minutes.AddDefinition(CastingTimeUnit);
      public static readonly Thing Hours = TimeUnits.Hours.AddDefinition(CastingTimeUnit);
      internal static void AddData(DataStructure dataStructure) =>
        dataStructure.AddRange(Action, BonusAction, Reaction, Minutes, Hours);
    }
    static class Spells
    {
      #region TypeDefintion
      public static FieldDefinition Level = new FieldDefinition("Level", Core.Value.DataType.Integer);
      public static FieldDefinition castingTimeUnitCount = new FieldDefinition("Count", Core.Value.DataType.Integer);
      public static RelationDefinition Spell_CastingTimeUnit = new RelationDefinition("Casting Time", "spells")
        .AddFieldDefinition(castingTimeUnitCount);

      #endregion
      public static ThingDefinition Spell = new ThingDefinition(Scope, "spell")
        .AddFieldDefinition(Level)
        .AddRelationDefinition(Spell_CastingTimeUnit)
        .AddRelationDefinition(Books.inBook)
      ;
      #region Schools
      public static ThingDefinition School = new(Scope, "school");
      public static Thing sch_Abjuration = new Idea("Abjuration").AddDefinition(School);
      public static Thing sch_Conjuration = new Idea("Conjuration").AddDefinition(School);
      public static Thing sch_Transmutation = new Idea("Transmutation").AddDefinition(School);
      public static RelationDefinition spell_school = new RelationDefinition("school", null);
      #endregion
      #region Instances
      static readonly Idea acidSplash = new Idea("Acid Splash");
      static readonly Idea aid = new Idea("Aid");
      static readonly Idea alarm = new Idea("Alarm");
      static readonly Idea alterSelf = new Idea("Alter Self");
      #endregion
      static Spells()
      {
        
        acidSplash.AddDefinition(Spell)
          .AddRelationFrom(Books.inBook, Books.phb).LastRelationFrom.AddValue(Books.atPage, 211).From
          .AddValue(Level, 0)
          .AddRelationFrom(spell_school, sch_Conjuration)
          .AddRelationFrom(Spell_CastingTimeUnit, CastingTimeUnits.Action).LastRelationFrom.AddValue(castingTimeUnitCount, 1)
        ;
        aid.AddDefinition(Spell)
          .AddValue(Level, 2)
          .AddRelationFrom(spell_school, sch_Abjuration)
        ;
        alarm.AddDefinition(Spell)
          .AddValue(Level, 1)
          .AddRelationFrom(spell_school, sch_Abjuration)
        ;
        alterSelf.AddDefinition(Spell)
          .AddValue(Level, 1)
          .AddRelationFrom(spell_school, sch_Transmutation)
        ;
      }
      internal static void AddData(DataStructure dataStructure) =>
        dataStructure.AddRange(acidSplash, aid, alarm, alterSelf);
    }
  }
}