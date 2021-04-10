using System;
using System.Collections.Generic;
using Placer.Seed.Reimplementations;

namespace Placer.Seed
{
  internal static class Youtube
  {
    public static DataStructure Data = new();
    readonly static Scope Scope = new Scope("Youtube", Reality.Internet);
    readonly static ThingDefinition Channel = new ThingDefinition(Scope, "Youtube Channel", 10, 40) { ID = new Guid("455EE97F-DD21-4D00-9A57-7FADDE5E6527")};
    readonly static FieldDefinition c_c = new FieldDefinition("c", Core.Value.DataType.String) { ID = new Guid("B8B569DE-97F6-4EF5-9FBE-8E930B692E5D") };
    readonly static FieldDefinition c_channel = new FieldDefinition("channel", Core.Value.DataType.String) { ID = new Guid("DDF65D84-05F1-4854-A770-8F1BC6C0D096") };
    readonly static FieldDefinition c_user = new FieldDefinition("user", Core.Value.DataType.String) { ID = new Guid("E5AC9517-BBE1-41D0-99C3-79DC4BC5D9BB") };
    readonly static FieldDefinition v = new FieldDefinition("v", Core.Value.DataType.String) { ID = new Guid("4C0DE951-0953-4E16-8DFC-DFAFFFE9C07A") };
    readonly static ThingDefinition Video = new ThingDefinition(Scope, "Youtube Video", 20, 30) { ID = new Guid("9A203AF6-9CDE-45AB-91F0-E8A7DC102194") };
    readonly static ThingDefinition Comment = new ThingDefinition(Scope, "Youtube Comment") { ID = new Guid("DA06A404-0E85-4C9D-A6B9-2A9C2726BF23") };
    readonly static RelationDefinition video_channel = new RelationDefinition(Scope, "channel", "video") { ID = new Guid("6A752066-C36C-4665-86DC-D34C6EA2525C") };
    readonly static RelationDefinition comment_channel = new RelationDefinition(Scope, "authored by", "made") { ID = new Guid("51450F5F-C249-467F-A945-564693C41A3F") };
    static Youtube()
    {
      M1();
      video_channel.AddRestriction(Core.RelationDefinitionRestriction.RestrictionType.Require, Video, Channel);
      comment_channel.AddRestriction(Core.RelationDefinitionRestriction.RestrictionType.Require, Comment, Channel);
      Channel
        .AddFieldDefinitions(c_c, c_channel)
        .AddFormat(new Format("url", 100).Add("https://www.youtube.com/c/").Add(c_c))
        .AddFormat(new Format("url", 90).Add("https://www.youtube.com/user/").Add(c_user))
        .AddFormat(new Format("url", 50).Add("https://www.youtube.com/channel/").Add(c_channel))
      ;
      Video.AddFieldDefinitions(v)
        .AddFormat(new Format("url", 100).Add("https://www.youtube.com/watch?v=").Add(v))
      ;
      Comment
        .AddFieldDefinitions(
          new FieldDefinition("Text", Core.Value.DataType.String)
        )
        
      ;
      Data.AddRange(Channel, Video, Comment);
    }
    private static void M1()
    {
      var luxe92 = new Thing(Channel, "luxe92") { ID = new Guid("E9948287-5809-4CB1-B1E4-5C9E77AAAD13") }
        .AddValue(c_channel, "UCgUxA-tPTnghCdNbbYDw5XA")
        .AddValue(c_user, "luxe1992")
        ;
      var rytisk = new Thing(Channel, "Rytis K.") { ID = new Guid("926E382B-A011-42B7-938B-CEF252F2D37A") }
        .AddValue(c_channel, "UC4gOz2qrX5OLDmtFGUEOMoQ")
        .AddValue(c_user, "mvp4lithuania")
        ;
      var negyvasEteris = new Idea(null, "Negyvas Eteris").AddDefinition(Channel)
        .AddValue(c_c, "NegyvasEteris")
        .AddValue(c_channel, "UChrJ09nCp7pp2pqp0SgJdNQ")
      ;
      var ziniuRadijas = new Thing(Channel, "Žinių radijas") { ID = new Guid("44E7448A-4E69-4EF1-AA43-023412999F86") }
        .AddValue(c_c, "ZiniuTV")
        .AddValue(c_channel, "UCPg6jj8aU_NBQIVQGLDpvEQ")
      ;
      Data.AddRange(
        new Thing(Video, "\"Nereikalingas Talentas: Pusfinalis\"") { Start = new DateTime(2021, 03, 26) }
          .AddValue(v, "8JEoJS6PJ0U")
          .AddRelationFrom(video_channel, negyvasEteris),
        new Thing(Video, "KUR PASTATYTI MAŠINĄ?") { Start = new DateTime(2021, 04, 06, 12, 00, 00) }
          .AddValue(v, "Tb3koKfl9JQ")
          .AddRelationFrom(video_channel, negyvasEteris),
        new Thing(Video, "\"Svarus pokalbis\": Gabrielius Svaras Liaudanskas ir grupė „Ugniavijas“\n") { Start = new DateTime(2017, 06, 25)  }
        .AddValue(v, "xoV2v6uCtN0")
        .AddRelationFrom(video_channel, ziniuRadijas)
        .AddRelationTo(Reality.dalyvavo, Lietuva.Ugniavijas)
      );
      Data.AddRange(
        new Thing(Comment, "ble paskutinis bičiukas yra žvaigždė....")
          .AddRelationFrom(comment_channel, luxe92),
        new Thing(Comment, "Blem tas paskutinis geresnis už tą australą, kur dalyvavo talentuos")
          .AddRelationFrom(comment_channel, rytisk)
      );
    }
  }
}