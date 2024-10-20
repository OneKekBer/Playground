using MainVV;
using System;
using System.Linq;
using System.Reflection;

namespace Playground.pg.Reflection
{
    public class Program
    {
        public static void Start()
        {
            var container = new DiContainer();

            container.Register<IDatabaseContext, DatabaseContext>();
            container.Register<IControllerBase, Controller>();


            var controller = container.Resolve<IControllerBase>() as Controller;
            controller.Method1(); // Вызов метода для проверки работы

        }

        public interface IDatabaseContext
        {
            void GetById();
        }

        public class DatabaseContext : IDatabaseContext
        {
            public void GetById()
            {
                Console.WriteLine("Fetching by ID");
            }
        }

        public interface IControllerBase { }

        public class Controller : IControllerBase
        {
            private readonly IDatabaseContext _databaseContext;

            // Зависимость передается через конструктор
            public Controller(IDatabaseContext databaseContext)
            {
                _databaseContext = databaseContext;
            }

            public void Method1()
            {
                Console.WriteLine("Method 1");
                _databaseContext.GetById();
            }
        }

        // 3. Простой DI контейнер
        public class DiContainer
        {
            private readonly Dictionary<Type, Type> _registrations = new Dictionary<Type, Type>();

            public void Register<TService, TImplementation>() where TImplementation : TService
            {
                _registrations[typeof(TService)] = typeof(TImplementation);
            }

            public object Resolve(Type serviceType)
            {
                if (!_registrations.ContainsKey(serviceType))
                {
                    throw new Exception($"Сервис {serviceType.Name} не зарегистрирован.");
                }

                var implementationType = _registrations[serviceType];
                var constructor = implementationType.GetConstructors().First();

                var parameters = constructor.GetParameters()
                    .Select(param => Resolve(param.ParameterType))
                    .ToArray();

                return Activator.CreateInstance(implementationType, parameters);
            }

            public TService Resolve<TService>()
            {
                return (TService)Resolve(typeof(TService));
            }
        }
    }

}
