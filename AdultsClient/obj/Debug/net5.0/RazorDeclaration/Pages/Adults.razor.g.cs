// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace AdultsClient.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\ionge\Desktop\VIA UNIVERSITY\3sem\DNP1\DNP1\AdultsClient\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\ionge\Desktop\VIA UNIVERSITY\3sem\DNP1\DNP1\AdultsClient\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\ionge\Desktop\VIA UNIVERSITY\3sem\DNP1\DNP1\AdultsClient\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\ionge\Desktop\VIA UNIVERSITY\3sem\DNP1\DNP1\AdultsClient\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\ionge\Desktop\VIA UNIVERSITY\3sem\DNP1\DNP1\AdultsClient\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\ionge\Desktop\VIA UNIVERSITY\3sem\DNP1\DNP1\AdultsClient\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\ionge\Desktop\VIA UNIVERSITY\3sem\DNP1\DNP1\AdultsClient\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\ionge\Desktop\VIA UNIVERSITY\3sem\DNP1\DNP1\AdultsClient\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\ionge\Desktop\VIA UNIVERSITY\3sem\DNP1\DNP1\AdultsClient\_Imports.razor"
using AdultsClient;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\ionge\Desktop\VIA UNIVERSITY\3sem\DNP1\DNP1\AdultsClient\_Imports.razor"
using AdultsClient.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\ionge\Desktop\VIA UNIVERSITY\3sem\DNP1\DNP1\AdultsClient\Pages\Adults.razor"
using AdultsClient.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\ionge\Desktop\VIA UNIVERSITY\3sem\DNP1\DNP1\AdultsClient\Pages\Adults.razor"
using AdultsClient.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\ionge\Desktop\VIA UNIVERSITY\3sem\DNP1\DNP1\AdultsClient\Pages\Adults.razor"
using System.Collections;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\ionge\Desktop\VIA UNIVERSITY\3sem\DNP1\DNP1\AdultsClient\Pages\Adults.razor"
using Microsoft.AspNetCore.Mvc.Filters;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/Adults")]
    public partial class Adults : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 81 "C:\Users\ionge\Desktop\VIA UNIVERSITY\3sem\DNP1\DNP1\AdultsClient\Pages\Adults.razor"
       
    private IList<Adult> adults;
    private IList<Adult> adultsToShow;

    private int? filterById;
    private string? filterByHairColor;

    private void FilterByAdultId(ChangeEventArgs changeEventArgs)
    {
        filterById = null;
        try
        {
            filterById = int.Parse(changeEventArgs.Value.ToString());
        }
        catch (Exception e)
        {
            
        }
        ExecuteFilter();
    }

    private void FilterByHairColor(ChangeEventArgs args)
    {
        filterByHairColor = null;
        try
        {
            filterByHairColor = args.Value.ToString();
        }
        catch (Exception e)
        {
            
        }
        ExecuteFilter();
    }

    private void ExecuteFilter()
    {
        adultsToShow = adults.Where(t =>
            (filterById != null && t.Id == filterById || filterById == null) &&
            (filterByHairColor != null && t.HairColor == filterByHairColor || filterByHairColor == null)).ToList();
    }
    protected override async Task OnInitializedAsync()
    {
        adults = await AdultData.GetAdultsAsync();
        adultsToShow = adults;
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        adults = await AdultData.GetAdultsAsync();
     
    }

    private async Task RemoveAdult(int AdultId)
    {
        Adult adultToRemove = adultsToShow.First(t => t.Id == AdultId);
        try
        {
            await AdultData.RemoveAdultAsync(AdultId);
            adults.Remove(adultToRemove);
            adultsToShow.Remove(adultToRemove);
            Console.WriteLine(adultsToShow[adultsToShow.Count-1].FirstName);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IAdultsService AdultData { get; set; }
    }
}
#pragma warning restore 1591
