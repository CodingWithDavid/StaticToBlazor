﻿using Microsoft.AspNetCore.Components;
using System;

namespace Blazored.Modal.Services
{
    public class ModalService : IModalService
    {
        /// <summary>
        /// Invoked when the modal component closes.
        /// </summary>
        public event Action<ModalResult> OnClose;

        /// <summary>
        /// Internal event used to trigger the modal component to show.
        /// </summary>
        internal event Action<string, RenderFragment, ModalParameters> OnShow;

        /// <summary>
        /// Shows the modal using the specified title and component type.
        /// </summary>
        /// <param name="title">Modal title.</param>
        /// <param name="componentType">Type of component to display.</param>
        public void Show(string title, Type componentType)
        {
            Show(title, componentType, new ModalParameters());
        }

        /// <summary>
        /// Shows the modal using the specified <paramref name="title"/> and <paramref name="componentType"/>, 
        /// passing the specified <paramref name="parameters"/>. 
        /// </summary>
        /// <param name="title">Modal title.</param>
        /// <param name="componentType">Type of component to display.</param>
        /// <param name="parameters">Key/Value collection of parameters to pass to component being displayed.</param>
        public void Show(string title, Type componentType, ModalParameters parameters)
        {
            if (!typeof(ComponentBase).IsAssignableFrom(componentType))
            {
                throw new ArgumentException($"{componentType.FullName} must be a Blazor Component");
            }

            var content = new RenderFragment(x => { x.OpenComponent(1, componentType); x.CloseComponent(); });

            OnShow?.Invoke(title, content, parameters);
        }

        /// <summary>
        /// Closes the modal and invokes the <see cref="OnClose"/> event.
        /// </summary>
        public void Cancel()
        {
            OnClose?.Invoke(ModalResult.Cancel());
        }

        /// <summary>
        /// Closes the modal and invokes the <see cref="OnClose"/> event with the specified <paramref name="modalResult"/>.
        /// </summary>
        /// <param name="modalResult"></param>
        public void Close(ModalResult modalResult)
        {
            OnClose?.Invoke(modalResult);
        }
    }
}
