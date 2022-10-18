# Splitter component
This article demonstrates how to use Splitter.

```
<Property365Splitter Orientation="Orientation.Vertical" Collapse=@OnCollapse Expand=@OnExpand style="height: 400px; border: 1px solid #777777;">
    <Property365SplitterPane Size="100px">
        <Property365Splitter Collapse=@OnCollapse Expand=@OnExpand>
            <Property365SplitterPane Size="50%" Min="30px" Max="70%">
                Pane A1
                <div style="font-size: 10px;">
                    50% Min 30px Max 70%
                </div>
            </Property365SplitterPane>
            <Property365SplitterPane>
                Pane A2
            </Property365SplitterPane>
        </Property365Splitter>
    </Property365SplitterPane>
    <Property365SplitterPane Size="100px">
        <Property365Splitter Collapse=@OnCollapse Expand=@OnExpand Resize=@OnResize>
            <Property365SplitterPane Size="50px" Min="30px">
                Pane B1
                <div style="font-size: 10px;">
                    Size 50px Min 30px
                </div>
            </Property365SplitterPane>
            <Property365SplitterPane>
                Pane B2
            </Property365SplitterPane>
            <Property365SplitterPane Resizable="false">
                Pane B3
                <div style="font-size: 10px;">
                    not resizable
                </div>
            </Property365SplitterPane>
            <Property365SplitterPane Min="10%">
                Pane B4
                <div style="font-size: 10px;">
                    Min 10%
                </div>
            </Property365SplitterPane>
            <Property365SplitterPane Collapsible="false">
                Pane B5
                <div style="font-size: 10px;">
                    not collapsible
                </div>
            </Property365SplitterPane>
            <Property365SplitterPane Visible="false">
                Pane B6
            </Property365SplitterPane>
            <Property365SplitterPane Resizable="false">
                Pane B7
                <div style="font-size: 10px;">
                    not resizable
                </div>
            </Property365SplitterPane>
            <Property365SplitterPane>
                Pane B8
            </Property365SplitterPane>
        </Property365Splitter>
    </Property365SplitterPane>
    <Property365SplitterPane>
        <Property365Splitter Collapse=@OnCollapseDisabled Resize=@OnResizeDisabled>
            <Property365SplitterPane>
                Pane C1
                <div style="font-size: 10px;">
                    collapse and resize programmatically disabled
                </div>
            </Property365SplitterPane>
            <Property365SplitterPane>
                Pane C2
                <div style="font-size: 10px;">
                    collapse and resize programmatically disabled
                </div>
            </Property365SplitterPane>
        </Property365Splitter>
    </Property365SplitterPane>
</Property365Splitter>

@code {
    void OnCollapse(Property365SplitterEventArgs args)
    {
        Console.WriteLine($"Pane {args.PaneIndex} Collapse");
    }

    void OnExpand(Property365SplitterEventArgs args)
    {
        Console.WriteLine($"Pane {args.PaneIndex} Expand");
    }

    void OnResize(Property365SplitterResizeEventArgs args)
    {
        Console.WriteLine($"Pane {args.PaneIndex} Resize (New size {args.NewSize})");
    }

    void OnCollapseDisabled(Property365SplitterEventArgs args)
    {
        args.Cancel = true;
        Console.WriteLine($"Pane {args.PaneIndex} Collapse programmatically disabled");
    }

    void OnResizeDisabled(Property365SplitterResizeEventArgs args)
    {
        args.Cancel = true;
        Console.WriteLine($"Pane {args.PaneIndex} Resize (New size {args.NewSize}) programmatically disabled");
    }
}
```