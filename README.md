# Autofac On Functions Liftime Scope Sample
Azure Function Autofac Integration, using version 1 available in nuget!

Forked from [AutofacOnFunctions](https://github.com/holgerleichsenring/AutofacOnFunctions)

Key updates...

# Named Services

First register your services by name.
```C#
    public class ServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TestIt>().As<ITestIt>();

            builder.RegisterType<PerDependency>().As<IPerDependency>().InstancePerDependency();
            builder.RegisterType<PerLifetimeScope>().As<IPerLifetimeScope>().InstancePerLifetimeScope();
            builder.RegisterType<PerSingleInstance>().As<IPerSingleInstance>().SingleInstance();

            builder.RegisterType<TestItByName>().Named<ITestItByName>("registration1");
            builder.RegisterType<TestItByName>().Named<ITestItByName>("registration2");
        }
    }
```

Use the inject atttribute to specify the named instance:
```C#
public static class Function1
    {
        [FunctionName("Function1")]
        public static IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]
            HttpRequest request
            , [Inject]
            ILogger logger
            , [Inject]
            ITestIt testIt
        )
        {
            log.Info("C# HTTP trigger function processed a request.");
            return new OkObjectResult($"Hello, this is Function1. Dependency injection sample returns \n'{testitbyName1.CallMe()}', \n'{testIt.CallMe()}'");
        }
    }
```

Original samples is available 

- [net standard](https://github.com/holgerleichsenring/AutofacOnFunctions/tree/master/AutofacOnFunctions/AutofacOnFunctions.Samples.NetStandard)
- [net framework](https://github.com/holgerleichsenring/AutofacOnFunctions/tree/master/AutofacOnFunctions/AutofacOnFunctions.Samples.NetFramework)

