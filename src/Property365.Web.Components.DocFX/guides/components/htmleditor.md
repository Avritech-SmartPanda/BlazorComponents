# HtmlEditor component
This article demonstrates how to use Property365HtmlEditor.

## Get and set the value
As all Property365 Blazor input components the HtmlEditor has a `Value` property which gets and sets the value of the component.
Use `@bind-Value` to get the user input.

```
<Property365HtmlEditor @bind-Value=@htmlValue />
@code {
  string htmlValue = "<h1>Hello World!!!</h1>";
}
```

## Tools
The HtmlEditor provides various tools for content editing - bold, italic, color, various text formatting etc.
By default all tools are enabled. Here is how to specify a custom set of tools:

```
<Property365HtmlEditor @bind-Value=@value>
  <Property365HtmlEditorUndo />
  <Property365HtmlEditorRedo />
  <Property365HtmlEditorSeparator />
  <Property365HtmlEditorBold />
  <Property365HtmlEditorItalic />
  <Property365HtmlEditorUnderline />
  <Property365HtmlEditorStrikeThrough />
  <Property365HtmlEditorSeparator />
  <Property365HtmlEditorColor />
  <Property365HtmlEditorBackground />
  <Property365HtmlEditorRemoveFormat />
</Property365HtmlEditor>
```

### All tools
The Property365 HtmlEditor supports the following tools:

- Property365HtmlEditorUndo - allows the user to undo the last action (result of other tool, typing or pasting).
- Property365HtmlEditorRedo - allows the use to redo the last undone action.
- Property365HtmlEditorSeparator - displays a vertical separator used to delimit group of similar tools.
- Property365HtmlEditorBold - toggles the bold style of the selected text.
- Property365HtmlEditorItalic - toggles the italic style of the selected text.
- Property365HtmlEditorUnderline - toggles the underline style of the selected text.
- Property365HtmlEditorStrikeThrough - toggles the strikethrough style of the selected text.
- Property365HtmlEditorAlignLeft - toggles left text alignment.
- Property365HtmlEditorAlignCenter - toggles center text alignment.
- Property365HtmlEditorAlignRight - toggles right text alignment.
- Property365HtmlEditorJustify - toggles justified text alignment.
- Property365HtmlEditorIndent - indents the selected text.
- Property365HtmlEditorOutdent - outdents the selected text.
- Property365HtmlEditorUnorderedList - inserts unordered (bullet) list.
- Property365HtmlEditorOrderedList - inserts ordered (numbered) list.
- Property365HtmlEditorColor - sets the foreground color of the selected text.
- Property365HtmlEditorBackground - sets the background color of the selected text.
- Property365HtmlEditorRemoveFormat - removes the visual styling of the selected text.
- Property365HtmlEditorSubscript - converts the selected text to subscript.
- Property365HtmlEditorSuperscript - converts the selected text to superscript
- Property365HtmlEditorLink - inserts a hyperlink.
- Property365HtmlEditorUnlink - removes a hyperlink.
- Property365HtmlEditorImage - allows the user to insert an image by either uploading a file or selecting a URL. Requires File upload to be implemented and the `UploadUrl` property of the HtmlEditor to be set.
- Property365HtmlEditorFontName - set the font of the selected text.
- Property365HtmlEditorFontSize - set the font size of the selected text.
- Property365HtmlEditorFormatBlock - allows the user to format the selected text as heading or paragraph.
- Property365HtmlEditorCustomTool - allows the developer to implement a [custom tool](#custom-tools).

### Default tools

By default Property365HtmlEditor uses these tools:

```
<Property365HtmlEditorUndo />
<Property365HtmlEditorRedo />
<Property365HtmlEditorSeparator />
<Property365HtmlEditorBold />
<Property365HtmlEditorItalic />
<Property365HtmlEditorUnderline />
<Property365HtmlEditorStrikeThrough />
<Property365HtmlEditorSeparator />
<Property365HtmlEditorAlignLeft />
<Property365HtmlEditorAlignCenter />
<Property365HtmlEditorAlignRight />
<Property365HtmlEditorJustify />
<Property365HtmlEditorSeparator />
<Property365HtmlEditorIndent />
<Property365HtmlEditorOutdent />
<Property365HtmlEditorUnorderedList />
<Property365HtmlEditorOrderedList />
<Property365HtmlEditorSeparator />
<Property365HtmlEditorColor />
<Property365HtmlEditorBackground />
<Property365HtmlEditorRemoveFormat />
<Property365HtmlEditorSeparator />
<Property365HtmlEditorSubscript />
<Property365HtmlEditorSuperscript />
<Property365HtmlEditorSeparator />
<Property365HtmlEditorLink />
<Property365HtmlEditorUnlink />
<Property365HtmlEditorImage />
<Property365HtmlEditorFontName />
<Property365HtmlEditorFontSize />
<Property365HtmlEditorFormatBlock />
```
### Custom tools
Property365HtmlEditor allows the developer to create custom tools via the `Property365HtmlEditorCustomTool` tag.

In its basic form you create a button and handle the `Execute` event of the HtmlEditor to implement the command.

```
<Property365HtmlEditor Execute=@OnExecute>
    <Property365HtmlEditorCustomTool CommandName="InsertToday" Icon="today" Title="Insert today" />
</Property365HtmlEditor>
@code {
    async Task OnExecute(HtmlEditorExecuteEventArgs args)
    {
        if (args.CommandName == "InsertToday")
        {
            var date = DateTime.Now;
            await args.Editor.ExecuteCommandAsync(HtmlEditorCommands.InsertHtml, $"<strong>{date.ToLongDateString()}</strong>");
        }
    }
}
```

You can also specify custom UI via the `Template` of the Property365HtmlEditorCustomTool.

```
<Property365HtmlEditor>
    <Property365HtmlEditorCustomTool>
        <Template Context="editor">
            <Property365DatePicker Change=@(args => OnDateChange(args, editor)) TValue="DateTime" />
        </Template>
    </Property365HtmlEditorCustomTool>
</Property365HtmlEditor>
@code {
  async Task OnDateChange(DateTime? date, Property365HtmlEditor editor)
  {
      if (date != null)
      {
          await editor.ExecuteCommandAsync(HtmlEditorCommands.InsertHtml, $"<strong>{date.Value.ToLongDateString()}</strong>");
      }
  }
}
```
## Upload files
Property365HtmlEditor requires file upload support to be implemented for uploading and pasting images. Here is a minimal implementation
that stores the uploaded files in the `wwwroot` directory of the application and uses GUID for the file names to avoid naming conflicts.

# [Page](#tab/page)
```
<Property365HtmlEditor UploadUrl="upload/image" />
```
# [Controller](#tab/controller)
```
using System;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;

namespace YourApplicationNamespace.Controllers
{
    public partial class UploadController : Controller
    {
        private readonly IWebHostEnvironment environment;

        public UploadController(IWebHostEnvironment environment)
        {
            this.environment = environment;
        }

        [HttpPost("upload/image")]
        public IActionResult Image(IFormFile file)
        {
            try
            {
                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";

                using (var stream = new FileStream(Path.Combine(environment.WebRootPath, fileName), FileMode.Create))
                {
                    // Save the file
                    file.CopyTo(stream);

                    // Return the URL of the file
                    var url = Url.Content($"~/{fileName}");

                    return Ok(new { Url = url });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
```
