using Microsoft.AspNetCore.Components;

namespace Property365.Web.Components
{
    /// <summary>
    /// Base class that Property365HtmlEditor color picker tools inherit from.
    /// </summary>
    public abstract class Property365HtmlEditorButtonBase : ComponentBase
    {
        /// <summary>
        /// The Property365HtmlEditor component which this tool is part of.
        /// </summary>
        [CascadingParameter]
        public Property365HtmlEditor Editor { get; set; }

        /// <summary>
        /// Specifies the name of the command. It is available as <see cref="HtmlEditorExecuteEventArgs.CommandName" /> when
        /// <see cref="Property365HtmlEditor.Execute" /> is raised.
        /// </summary>
        protected virtual string CommandName { get; }

        /// <summary>
        /// Handles the click event of the button. Executes the command.
        /// </summary>
        protected virtual async Task OnClick()
        {
            await Editor.ExecuteCommandAsync(CommandName);
        }
    }
}
