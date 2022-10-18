﻿using System.Collections;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Property365.Web.Components.Rendering;

namespace Property365.Web.Components
{
    /// <summary>
    /// Class DataBoundFormComponent.
    /// Implements the <see cref="Property365.Web.Components.Property365Component" />
    /// Implements the <see cref="Property365.Web.Components.IProperty365FormComponent" />
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="Property365.Web.Components.Property365Component" />
    /// <seealso cref="Property365.Web.Components.IProperty365FormComponent" />
    public class DataBoundFormComponent<T> : Property365Component, IProperty365FormComponent
    {
        /// <summary>
        /// Gets or sets the index of the tab.
        /// </summary>
        /// <value>The index of the tab.</value>
        [Parameter]
        public int TabIndex { get; set; } = 0;

        /// <summary>
        /// Gets or sets the filter case sensitivity.
        /// </summary>
        /// <value>The filter case sensitivity.</value>
        [Parameter]
        public FilterCaseSensitivity FilterCaseSensitivity { get; set; } = FilterCaseSensitivity.Default;

        /// <summary>
        /// Gets or sets the filter operator.
        /// </summary>
        /// <value>The filter operator.</value>
        [Parameter]
        public StringFilterOperator FilterOperator { get; set; } = StringFilterOperator.Contains;

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [Parameter]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the placeholder.
        /// </summary>
        /// <value>The placeholder.</value>
        [Parameter]
        public string Placeholder { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="DataBoundFormComponent{T}"/> is disabled.
        /// </summary>
        /// <value><c>true</c> if disabled; otherwise, <c>false</c>.</value>
        [Parameter]
        public bool Disabled { get; set; }

        /// <summary>
        /// Gets or sets the change.
        /// </summary>
        /// <value>The change.</value>
        [Parameter]
        public EventCallback<object> Change { get; set; }

        /// <summary>
        /// Gets or sets the load data.
        /// </summary>
        /// <value>The load data.</value>
        [Parameter]
        public EventCallback<Property365.Web.Components.LoadDataArgs> LoadData { get; set; }

        /// <summary>
        /// The form
        /// </summary>
        IProperty365Form _form;

        /// <summary>
        /// Gets or sets the form.
        /// </summary>
        /// <value>The form.</value>
        [CascadingParameter]
        public IProperty365Form Form
        {
            get
            {
                return _form;
            }
            set
            {
                _form = value;
                _form?.AddComponent(this);
            }
        }

        /// <summary>
        /// The value
        /// </summary>
        object _value;
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        [Parameter]
        public object Value
        {
            get
            {
                return _value;
            }
            set
            {
                if (_value != value)
                {
                    _value = object.Equals(value, "null") ? null : value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the value changed.
        /// </summary>
        /// <value>The value changed.</value>
        [Parameter]
        public EventCallback<T> ValueChanged { get; set; }

        /// <summary>
        /// Gets a value indicating whether this instance is bound.
        /// </summary>
        /// <value><c>true</c> if this instance is bound; otherwise, <c>false</c>.</value>
        public bool IsBound
        {
            get
            {
                return ValueChanged.HasDelegate;
            }
        }
        /// <summary>
        /// Gets a value indicating whether this instance has value.
        /// </summary>
        /// <value><c>true</c> if this instance has value; otherwise, <c>false</c>.</value>
        public virtual bool HasValue
        {
            get
            {
                if (typeof(T) == typeof(string))
                {
                    return !string.IsNullOrEmpty($"{Value}");
                }
                return Value != null;
            }
        }

        /// <summary>
        /// Gets or sets the text property.
        /// </summary>
        /// <value>The text property.</value>
        [Parameter]
        public string TextProperty { get; set; }

        /// <summary>
        /// The data
        /// </summary>
        IEnumerable _data = null;
        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>The data.</value>
        [Parameter]
        public virtual IEnumerable Data
        {
            get
            {
                return _data;
            }
            set
            {
                if (_data != value)
                {
                    _view = null;
                    _value = null;
                    _data = value;
                    StateHasChanged();
                }
            }
        }

        /// <summary>
        /// Called when [data changed].
        /// </summary>
        protected virtual async Task OnDataChanged()
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// Gets the query.
        /// </summary>
        /// <value>The query.</value>
        protected virtual IQueryable Query
        {
            get
            {
                return Data != null ? Data.AsQueryable() : null;
            }
        }

        /// <summary>
        /// The search text
        /// </summary>
        internal string searchText;

        /// <summary>
        /// The view
        /// </summary>
        protected IQueryable _view = null;
        /// <summary>
        /// Gets the view.
        /// </summary>
        /// <value>The view.</value>
        protected virtual IEnumerable View
        {
            get
            {
                if (_view == null && Query != null)
                {
                    if (!string.IsNullOrEmpty(searchText))
                    {
                        var ignoreCase = FilterCaseSensitivity == FilterCaseSensitivity.CaseInsensitive;

                        var query = new List<string>();

                        if (!string.IsNullOrEmpty(TextProperty))
                        {
                            query.Add(TextProperty);
                        }

                        if (ignoreCase)
                        {
                            query.Add("ToLower()");
                        }

                        query.Add($"{Enum.GetName(typeof(StringFilterOperator), FilterOperator)}(@0)");

                        _view = Query.Where(String.Join(".", query), ignoreCase ? searchText.ToLower() : searchText);
                    }
                    else
                    {
                        _view = (typeof(IQueryable).IsAssignableFrom(Data.GetType())) ? Query.Cast<object>().ToList().AsQueryable() : Query;
                    }
                }

                return _view;
            }
        }

        /// <summary>
        /// Gets or sets the edit context.
        /// </summary>
        /// <value>The edit context.</value>
        [CascadingParameter]
        public EditContext EditContext { get; set; }

        /// <summary>
        /// Gets the field identifier.
        /// </summary>
        /// <value>The field identifier.</value>
        public FieldIdentifier FieldIdentifier { get; private set; }

        /// <summary>
        /// Gets or sets the value expression.
        /// </summary>
        /// <value>The value expression.</value>
        [Parameter]
        public Expression<Func<T>> ValueExpression { get; set; }
        /// <summary>
        /// Set parameters as an asynchronous operation.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>A Task representing the asynchronous operation.</returns>
        public override async Task SetParametersAsync(ParameterView parameters)
        {
            var dataChanged = parameters.DidParameterChange(nameof(Data), Data);
            if (dataChanged)
            {
                await OnDataChanged();
            }

            var result = base.SetParametersAsync(parameters);

            if (EditContext != null && ValueExpression != null && FieldIdentifier.Model != EditContext.Model)
            {
                FieldIdentifier = FieldIdentifier.Create(ValueExpression);
                EditContext.OnValidationStateChanged += ValidationStateChanged;
            }

            await result;
        }

        /// <summary>
        /// Validations the state changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ValidationStateChangedEventArgs"/> instance containing the event data.</param>
        private void ValidationStateChanged(object sender, ValidationStateChangedEventArgs e)
        {
            StateHasChanged();
        }

        /// <summary>
        /// Disposes this instance.
        /// </summary>
        public override void Dispose()
        {
            base.Dispose();

            if (EditContext != null)
            {
                EditContext.OnValidationStateChanged -= ValidationStateChanged;
            }

            Form?.RemoveComponent(this);
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <returns>System.Object.</returns>
        public object GetValue()
        {
            return Value;
        }


        /// <summary>
        /// Gets the class list.
        /// </summary>
        /// <param name="className">Name of the class.</param>
        /// <returns>ClassList.</returns>
        protected ClassList GetClassList(string className) => ClassList.Create(className)
                                                                       .AddDisabled(Disabled)
                                                                       .Add(FieldIdentifier, EditContext);
    }
}
