## Qualisys Log

#### Nuget installation:

```
Install-Package QualisysLog -Version 1.0.4
```

#### Configuration:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
  <appSettings>
    <!-- LOG -->
    <add key="ShowConsole" value="false" />
    <add key="SaveEventLog" value="false" />
    <add key="FullLog" value="true" />
    <add key="LogName" value="AplicationLog" />
    <add key="LogPath" value="//Server/Apps/Log" />
  </appSettings>
</configuration>
```

#### Basic use:

```csharp
using System;
using QualisysLog;

public class Program
{
	public static void Main()
	{
            QsLog.WriteInfo("Para escribir información");
            QsLog.WriteSuccess("Para escribir proceso exitoso");
            QsLog.WriteTracking("Para escribir seguimiento de proceso");
            QsLog.WriteProcess("Para escribir proceso");
            QsLog.WriteWarning("Para escribir advertencia");
            QsLog.WriteError("Para escribir error");
            QsLog.WriteException("Para escribir excepción");
	}
}
```

See more

[Nuget package page](https://www.nuget.org/packages/QualisysLog/)