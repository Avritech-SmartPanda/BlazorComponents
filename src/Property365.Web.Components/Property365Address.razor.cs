using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Forms;
using Property365.Web.Components;
using Property365.Web.Components.Rendering;
using Property365.Web.Components.Models;

namespace Property365.Web.Components
{

    public partial class Property365Address<AddressViewModel>: Property365Component,IProperty365Form
    {

        /// <summary>
        /// A callback that will be invoked when the user clicks on a legend. 
        /// </summary>
        // [Parameter]
        // public EventCallback<LegendClickEventArgs> LegendClick { get; set; }
        // string? Address1 { get; set; }
        // string? Address2 { get; set; }
        // string? City { get; set; }
        // string? State { get; set; }
        // string? Country { get; set; }
        // int? Zip { get; set; }
        // string? AddressType { get; set; }

        /// <summary>
        /// Gets or sets the child content. Used to specify series and other configuration.
        /// </summary>
        /// <value>The child content.</value>
        //[Parameter]
        //public RenderFragment ChildContent { get; set; }



 






        /// <summary>
        /// Returns the validity of the form.
        /// </summary>
        /// <value><c>true</c> if all validators in the form a valid; otherwise, <c>false</c>.</value>
        public bool IsValid
        {
            get
            {
                if (EditContext == null)
                {
                    return true;
                }

                return !EditContext.GetValidationMessages().Any();
            }
        }

        /// <summary>
        /// Specifies the model of the form. Required to support validation.
        /// </summary>
        [Parameter]
        public AddressViewModel Data { get; set; }

        /// <summary>
        /// Gets or sets the child content.
        /// </summary>
        [Parameter]
        public RenderFragment<EditContext> ChildContent { get; set; }

        /// <summary>
        /// A callback that will be invoked when the user submits the form and <see cref="IsValid" /> is <c>true</c>.
        /// </summary>
        /// <example>
        /// <code>
        /// &lt;Address AddressViewModel="Model" Submit=@OnSubmit Data=@model&gt;
        ///   &lt;Property365TextBox style="display: block" Name="Email" @bind-Value=@model.Email /&gt;
        ///   &lt;Property365RequiredValidator Component="Email" Text="Email is required" Style="position: absolute" /&gt;
        /// &lt;/Address&gt;
        /// @code {
        ///  class Model
        ///   {
        ///    public string Email { get; set; }
        ///  }
        ///  
        ///  Model model = new Model();
        ///
        ///  void OnSubmit(Model value)
        ///  {
        ///  
        ///  }
        /// }
        /// </code>
        /// </example>
        [Parameter]
        public EventCallback<AddressViewModel> Submit { get; set; }

        /// <summary>
        /// Obsolete. Use <see cref="InvalidSubmit" /> instead.
        /// </summary>
        [Parameter]
        [Obsolete]
        public EventCallback<FormInvalidSubmitEventArgs> OnInvalidSubmit
        {
            get
            {
                return InvalidSubmit;
            }
            set
            {
                InvalidSubmit = value;
            }
        }

        /// <summary>
        /// A callback that will be invoked when the user submits the form and <see cref="IsValid" /> is <c>false</c>.
        /// </summary>
        /// <example>
        /// <code>
        /// &lt;Address AddressViewModel="Model" InvalidSubmit=@OnInvalidSubmit Data=@model&gt;
        ///   &lt;Property365TextBox style="display: block" Name="Email" @bind-Value=@model.Email /&gt;
        ///   &lt;Property365RequiredValidator Component="Email" Text="Email is required" Style="position: absolute" /&gt;
        /// &lt;/Address&gt;
        /// @code {
        ///  class Model
        ///  {
        ///    public string Email { get; set; }
        ///  }
        ///  
        ///  Model model = new Model();
        ///
        ///  void OnInvalidSubmit(FormInvalidSubmitEventArgs args)
        ///  {
        ///  
        ///  }
        /// }
        /// </code>
        /// </example>
        [Parameter]
        public EventCallback<FormInvalidSubmitEventArgs> InvalidSubmit { get; set; }

        /// <summary>
        /// Specifies the form <c>method</c> attribute. Used together with <see cref="Action" />.
        /// </summary>
        /// <example>
        /// <code>
        /// &lt;Address AddressViewModel="Model" Method="post" Action="/register" Data=@model&gt;
        ///   &lt;Property365TextBox style="display: block" Name="Email" @bind-Value=@model.Email /&gt;
        ///   &lt;Property365RequiredValidator Component="Email" Text="Email is required" Style="position: absolute" /&gt;
        /// &lt;/Address&gt;
        /// </code>
        /// </example>
        [Parameter]
        public string Method { get; set; }

        /// <summary>
        /// Specifies the form <c>action</c> attribute. When set the form submits to the specified URL.
        /// </summary>
        /// <example>
        /// <code>
        /// &lt;Address AddressViewModel="Model" Method="post" Action="/register" Data=@model&gt;
        ///   &lt;Property365TextBox style="display: block" Name="Email" @bind-Value=@model.Email /&gt;
        ///   &lt;Property365RequiredValidator Component="Email" Text="Email is required" Style="position: absolute" /&gt;
        /// &lt;/Address&gt;
        /// </code>
        /// </example>
        [Parameter]
        public string Action { get; set; }

        private readonly Func<Task> handleSubmitDelegate;

        /// <summary>
        /// Initializes a new instance of the <see cref="Address{AddressViewModel}"/> class.
        /// </summary>
        public Property365Address()
        {
            handleSubmitDelegate = OnSubmit;
        }

        /// <summary>
        /// Handles the submit event of the form.
        /// </summary>
        protected async Task OnSubmit()
        {
            if (EditContext != null)
            {
                bool valid = EditContext.Validate();

                if (valid)
                {
                    await Submit.InvokeAsync(Data);

                    if (Action != null)
                    {
                        await JSRuntime.InvokeVoidAsync($"Property365.Web.Components.submit", Element);
                    }
                }
                else
                {
                    await InvalidSubmit.InvokeAsync(new FormInvalidSubmitEventArgs() { Errors = EditContext.GetValidationMessages() });
                }
            }
            else
            {
                if (Action != null)
                {
                    await JSRuntime.InvokeVoidAsync($"Property365.Web.Components.submit", Element);
                }
            }
        }

        readonly List<IProperty365FormComponent> components = new List<IProperty365FormComponent>();

        /// <inheritdoc />
        public void AddComponent(IProperty365FormComponent component)
        {
            if (components.IndexOf(component) == -1)
            {
                components.Add(component);
            }
        }

        /// <inheritdoc />
        public void RemoveComponent(IProperty365FormComponent component)
        {
            components.Remove(component);
        }

        /// <inheritdoc />
        public IProperty365FormComponent FindComponent(string name)
        {
            return components.Where(component => component.Name == name).FirstOrDefault();
        }

        /// <summary>
        /// Gets or sets the edit context.
        /// </summary>
        /// <value>The edit context.</value>
        [Parameter]
        public EditContext EditContext { get; set; }

        /// <inheritdoc />
        protected override void OnParametersSet()
        {
            if (Data != null && (EditContext == null || EditContext.Model != (object)Data))
            {
                EditContext = new EditContext(Data);
            }
        }

        // /// <inheritdoc />
        // protected override void BuildRenderTree(RenderTreeBuilder builder)
        // {
        //     if (Visible)
        //     {
        //         if (Data != null)
        //         {
        //             builder.OpenRegion(Data.GetHashCode());
        //         }

        //         builder.OpenElement(0, "form");
        //         builder.AddAttribute(1, "style", Style);

        //         if (Action != null)
        //         {
        //             builder.AddAttribute(2, "method", Method);
        //             builder.AddAttribute(3, "action", Action);
        //         }

        //         builder.AddAttribute(4, "onsubmit", handleSubmitDelegate);
        //         builder.AddMultipleAttributes(5, Attributes);
        //         builder.AddAttribute(6, "class", GetCssClass());
        //         builder.AddElementReferenceCapture(7, form => Element = form);

        //         builder.OpenComponent<CascadingValue<IProperty365Form>>(8);
        //         builder.AddAttribute(9, "IsFixed", true);
        //         builder.AddAttribute(10, "Value", this);
        //         builder.AddAttribute(11, "ChildContent", new RenderFragment(contentBuilder =>
        //         {
        //             contentBuilder.OpenComponent<CascadingValue<EditContext>>(0);
        //             contentBuilder.AddAttribute(1, "IsFixed", true);
        //             contentBuilder.AddAttribute(2, "Value", EditContext);
        //             contentBuilder.AddAttribute(3, "ChildContent", ChildContent?.Invoke(EditContext));
        //             contentBuilder.CloseComponent();
        //         }));

        //         builder.CloseComponent(); // CascadingValue<IProperty365Form>


        //         builder.CloseElement(); // form

        //         if (Data != null)
        //         {
        //             builder.CloseRegion();
        //         }
        //     }
        // }
    }




}
