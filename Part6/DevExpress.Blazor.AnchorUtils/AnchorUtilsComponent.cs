﻿using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevExpress.Blazor.AnchorUtils {
    public class AnchorUtilsComponent: ComponentBase, IDisposable {
        [Inject] public NavigationManager NavigationManager { get; set; }
        [Inject] public IJSRuntime JSRuntime { get; set; }

        [Parameter] public RenderFragment ChildContent { get; set; }

        string Anchor { get; set; }

        bool ForceScroll { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();

            NavigationManager.LocationChanged += OnLocationChanged;
        }

        protected override Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
                ScrollToAnchor(forceScroll: true);

            return base.OnAfterRenderAsync(firstRender);
        }

        void OnLocationChanged(object sender, LocationChangedEventArgs args)
        {
            ScrollToAnchor(NavigationManager.ToAbsoluteUri(args.Location).Fragment);
        }

        void ScrollToAnchor(string anchor = "", bool forceScroll = false)
        {
            if (!string.IsNullOrEmpty(anchor) || forceScroll)
                JSRuntime.InvokeAsync<string>("scrollToAnchor", anchor);
        }

        void IDisposable.Dispose()
        {
            NavigationManager.LocationChanged -= OnLocationChanged;
        }
    }
}
