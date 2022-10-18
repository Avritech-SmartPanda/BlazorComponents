# Login component
This article demonstrates how to use the Login component. Should be used together with Property365TemplateForm with Data property set.

## Events
Use `Login`, `` and `` to catch events raised by Login component.
```
<Property365TemplateForm Data=@("SimpleLogin") Action="http://www.google.com">
    <Property365Login AllowRegister="true" AllowResetPassword="true" 
        Login=@OnLogin Register=@OnRegister ResetPassword=@OnResetPassword />
</Property365TemplateForm>

@code {
    string userName = "admin";
    string password = "admin";

    void OnLogin(LoginArgs args)
    {
        Console.WriteLine($"Username: {args.Username} and password: {args.Password}");
    }

    void OnRegister(string name)
    {
        Console.WriteLine($"{name} -> Register");
    }

    void OnResetPassword(string value, string name)
    {
        Console.WriteLine($"{name} -> ResetPassword for user: {value}");
    }
}
```

## Localization
```
<Property365TemplateForm Data=@("Localization")>
    <Property365Login AllowRegister="true" AllowResetPassword="true"
                LoginText="Einloggen" UserText="Benutzername" PasswordText="Passwort"
                UserRequired="Benutzername erforderlich"
                PasswordRequired="Passwort erforderlich"
                RegisterText="Registrieren"
                RegisterMessageText="Sie haben noch keinen Account?"
                ResetPasswordText="Passwort zurücksetzen" />
</Property365TemplateForm>
```