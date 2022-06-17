# TreeLogger ⚙️
UI Logger który działa w sposób asynchroniczny, pozwala sporządzać raport podczas całej pracy wykonania określonej pracy, przedstawia czas wykonania oraz poszczególne komunikaty zdefiniowane przez użytkonwika, może być dołączony do dowolnej .NET-aplikacji. Wspiera również asynchroniczne przerywanie korzystające z tokena.

# Implementacja w aplikacji 💡
1. Dołaczyć TreeLogger.dll  
2. Użyć w kodzie 😀 

*Pierwszy parametr określa nazwę logowanej operacji, drugi parametr przyjmuje delegat do opisania operacji.*  
  
Wersja bez możliwości asynchronicznego przerwania:
```c#
TreeLoggerRunner.RunTreeLogger("Ksiegowanie dokumentu", (logger) =>
{
    for(int i=0;i<10;i++)
    {
        logger.LogMessage($"Value = {i}", TreeLogger.Enums.MessageSeverity.Information);
    }
});
```
Wersja z asynchronicznym przerwaniem
```c#
TreeLoggerRunner.RunTreeLogger("Ksiegowanie dokumentu", (logger, token) =>
{
    for(int i=0;i<10;i++)
    {
        if(token.IsCancellationRequested) return;
        logger.LogMessage($"Value = {i}", TreeLogger.Enums.MessageSeverity.Information);
    }
});
```

Wersja z uruchamianiem subprocesów
```c#
TreeLoggerRunner.RunTreeLogger("Ksiegowanie dokumentu handlowego", (logger, token) =>
{
    logger.LogMessage("Ksiegowanie naglowka");
    logger.InitSubLogging();
    for(int i = 0;i <10;i++)
    {
        if (token.IsCancellationRequested) return;
        logger.LogMessage($"Aktualna wartosc : {i}", TreeLogger.Enums.MessageSeverity.Information);
    }
    logger.EndSubLogging();
    logger.LogMessage("Ksiegowanie stopki");
});
```

# Jak wygląda w praktyce
![default](https://user-images.githubusercontent.com/19534189/173612053-ffd19fda-d405-4b78-97e5-da9b5e682018.jpg)
![withasync](https://user-images.githubusercontent.com/19534189/173612058-c635c000-9b3d-459f-9c86-c67ea1574c94.jpg)
![Screenshot_2](https://user-images.githubusercontent.com/19534189/174396701-da4f9a12-497b-4b5e-802e-de668abcc6ba.jpg)


