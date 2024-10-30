namespace DoctorAppointmentDemo.UI.Helpers
{
    using DoctorAppointmentDemo.Domain.Entities;
    using DoctorAppointmentDemo.Domain.Exceptions;
    using DoctorAppointmentDemo.Domain.Interfaces;
    using System;
    using System.Collections.Generic;

    public static class EntityManager
    {
        public static void CreateEntity<T>(Func<T> promptFunction, Func<T, T> saveFunction) where T : Auditable, IValidatable
        {
            T entity = promptFunction();
            try
            {
                T savedEntity = saveFunction(entity);
                Console.WriteLine("Entity created succesfully with ID: " + savedEntity.Id);
                Console.WriteLine("Enter any key for continue...");
            }
            catch (ValidationException ex)
            {
                Console.WriteLine("Validation errors:");
                foreach (var error in ex.ValidationErrors)
                {
                    Console.WriteLine("- " + error);
                }
                Console.WriteLine("Enter any key for continue...");
            }
            Console.ReadKey();
        }

        public static void UpdateEntity<T>(Func<int, T> getFunction, Func<T, T> promptFunction, Func<int, T, T> updateFunction) where T : Auditable, IValidatable
        {
            int id = PromptForId();
            T existingEntity = getFunction(id);
            if (existingEntity == null)
            {
                Console.WriteLine($"Entity with ID {id} not found. Enter any key for continue...");
                Console.ReadKey();
                return;
            }

            T updatedEntity = promptFunction(existingEntity);

            try
            {
                T savedEntity = updateFunction(id, updatedEntity);
                Console.WriteLine("Entity updated succesfully with ID: " + savedEntity.Id);
                Console.WriteLine("Enter any key for continue...");
            }
            catch (ValidationException ex)
            {
                Console.WriteLine("Validation errors:");
                foreach (var error in ex.ValidationErrors)
                {
                    Console.WriteLine("- " + error);
                }
                Console.WriteLine("Enter any key for continue...");
            }
            Console.ReadKey();
        }

        public static void DeleteEntity(Func<int, bool> deleteFunction)
        {
            int id = PromptForId();
            if (deleteFunction(id))
            {
                Console.WriteLine("Entity deleted succesfully. Enter any key for continue...");
            }
            else
            {
                Console.WriteLine($"Entity with ID = {id} not found. Enter any key for continue...");
            }
            Console.ReadKey();
        }

        public static void GetEntity<T>(Func<int, T> getFunction)
        {
            int id = PromptForId();
            T entity = getFunction(id);
            if (entity != null)
            {
                Console.WriteLine(entity.ToString());
            }
            else
            {
                Console.WriteLine($"Entity with ID = {id} not found");
            }
            Console.WriteLine("Enter any key for continue...");
            Console.ReadKey();
        }

        public static void GetAllEntities<T>(Func<IEnumerable<T>> getAllFunction)
        {
            IEnumerable<T> entities = getAllFunction();
            foreach (var entity in entities)
            {
                Console.WriteLine(entity.ToString());
            }
            Console.WriteLine("Enter any key for continue...");
            Console.ReadKey();
        }

        private static int PromptForId()
        {
            Console.Write("Enter ID: ");
            return int.TryParse(Console.ReadLine(), out int id) ? id : 0;
        }
    }
}
