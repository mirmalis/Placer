using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Placer.Wasm1.Shared
{
  public abstract class GG<TCommon, TShallow, TDeep, TKey> : ComponentBase
      where TCommon : Api1.Types.IIDed<TKey>
      where TShallow : class, TCommon
      where TDeep : class, TCommon
      where TKey: struct
  {
    [Parameter] public TKey? ParamID { get; set; }
    [Parameter] public TShallow ParamShallow { get; set; }
    [Parameter] public TDeep ParamDeep { get; set; }
    [Parameter] public bool ParamShowLink { get; set; } = true;
    [Parameter] public bool ParamExpandable { get; set; } = true;
    [Parameter] public bool ParamExpanded { get; set; } = false;
    [Parameter] public bool ParamIsTopLevel { get; set; } = false;

    public TKey ID { get; set; }
    public TCommon Common => (TCommon)Deep ?? (TCommon)Shallow;
    public TShallow Shallow { get; set; }
    public TDeep Deep { get; set; }

    protected LinkTypes LinkType
    {
      get
      {
        if (!ParamShowLink || ParamIsTopLevel)
          return LinkTypes.None;
        if (ParamExpandable)
          return LinkTypes.NextToName;
        else
          return LinkTypes.EntireName;
      }
    }
    protected bool Expanded;
    protected bool IsDeep => Deep != null;
    protected bool IsShallow => Shallow != null;

    protected abstract Task<TDeep> GetDeep();
    protected async Task ToggleExpand()
    {
      if (!ParamExpandable)
        return;
      Expanded = !Expanded;
      await EnsureData();
    }

    protected override async Task OnParametersSetAsync()
    {
      await base.OnParametersSetAsync();
      this.ID = ParamID ?? ParamDeep?.ID ?? ParamShallow?.ID ?? throw new Exception("Provide ID");
      
      if (ParamIsTopLevel)
      {
        Expanded = true;
        ParamExpanded = true;
        ParamExpandable = false;
      }
      else
      {
        Expanded = ParamExpanded;
      }
      this.Shallow = ParamShallow;
      this.Deep = ParamDeep;
      await EnsureData();
    }
    protected async Task EnsureData()
    {
      if (Common == null || (Expanded && !IsDeep))
      {
        await RenewElement();
      }
    }
    virtual protected async Task RenewElement()
    {
      this.Deep = await GetDeep();
    }
  }
}
