using Clinicamedica;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace ClinicaMedica
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var context = new ClinicaContext();

            Console.WriteLine("=== SISTEMA DE GESTIÓN DE TURNOS ===");
            Console.Write("\n1. Ingrese el DNI del paciente: ");
            if (!int.TryParse(Console.ReadLine(), out int dniIngresado))
            {
                Console.WriteLine("DNI inválido. El programa finalizará.");
                return;
            }

            var paciente = context.Pacientes.FirstOrDefault(p => p.Dni == dniIngresado);

            if (paciente != null)
            {
                Console.WriteLine($"\n¡Bienvenido/a nuevamente, {paciente.Nombre} {paciente.Apellido}!");

                var turnosReservados = context.Turnos
                    .Include(t => t.Especialidad)
                    .Include(t => t.Medico)
                    .Include(t => t.Estado)
                    .Where(t => t.Dni == dniIngresado && t.Estado.Descripcion == "reservado")
                    .ToList();

                if (turnosReservados.Any())
                {
                    Console.WriteLine("\nTurnos reservados actualmente:");
                    for (int i = 0; i < turnosReservados.Count; i++)
                    {
                        var t = turnosReservados[i];
                        Console.WriteLine($"[{i + 1}] {t.Fecha} a las {t.Hora} | {t.Especialidad.Nombre} con Dr/a. {t.Medico.Apellido}");
                    }

                    Console.Write("\n¿Desea cancelar alguno de estos turnos? (S/N): ");
                    if (Console.ReadLine()?.Trim().ToUpper() == "S")
                    {
                        Console.Write("Ingrese el número del turno que desea cancelar: ");
                        if (int.TryParse(Console.ReadLine(), out int numTurno) && numTurno > 0 && numTurno <= turnosReservados.Count)
                        {
                            var turnoACancelar = turnosReservados[numTurno - 1];
                            var estadoCancelado = context.Estados.FirstOrDefault(e => e.Descripcion == "cancelado");
                            
                            turnoACancelar.IdEstado = estadoCancelado.IdEstado;
                            context.SaveChanges();
                            Console.WriteLine(">>> Turno cancelado exitosamente.");
                        }
                        else
                        {
                            Console.WriteLine("Número inválido.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("No tienes turnos reservados.");
                }
            }
            else
            {
                Console.WriteLine("\nPaciente no encontrado. Procedemos a registrarlo:");
                paciente = new Paciente { Dni = dniIngresado };
                
                Console.Write("Nombre: ");
                paciente.Nombre = Console.ReadLine();
                
                Console.Write("Apellido: ");
                paciente.Apellido = Console.ReadLine();
                
                Console.Write("Teléfono: ");
                paciente.Telefono = Console.ReadLine();
                
                Console.Write("Email: ");
                paciente.Email = Console.ReadLine();
                
                Console.Write("Fecha de nacimiento (YYYY-MM-DD): ");
                paciente.FechaNacimiento = Console.ReadLine();

                context.Pacientes.Add(paciente);
                context.SaveChanges();
                Console.WriteLine(">>> Paciente registrado exitosamente.");
            }

            Console.WriteLine("\n2. Seleccione una especialidad:");
            var especialidades = context.Especialidades.ToList();
            
            foreach (var esp in especialidades)
            {
                Console.WriteLine($"[{esp.IdEspecialidad}] {esp.Nombre}");
            }
            
            Console.Write("Ingrese el ID de la especialidad: ");
            int idEspecialidad = int.Parse(Console.ReadLine());
            var especialidadElegida = especialidades.FirstOrDefault(e => e.IdEspecialidad == idEspecialidad);

            if (especialidadElegida == null)
            {
                Console.WriteLine("Especialidad no válida. Finalizando...");
                return;
            }

            Console.WriteLine($"\n3. Médicos que atienden {especialidadElegida.Nombre}:");
            

            var disponibilidadesEspecialidad = context.Disponibilidades
                .Include(d => d.Medico)
                .Where(d => d.IdEspecialidad == idEspecialidad)
                .ToList();

            var medicos = disponibilidadesEspecialidad
                .Select(d => d.Medico)
                .DistinctBy(m => m.Matricula)
                .ToList();

            if (!medicos.Any())
            {
                Console.WriteLine("No hay médicos disponibles para esta especialidad.");
                return;
            }

            foreach (var med in medicos)
            {
                Console.WriteLine($"[{med.Matricula}] Dr/a. {med.Nombre} {med.Apellido}");
            }
            
            Console.Write("Ingrese la matrícula del médico: ");
            int matriculaMedico = int.Parse(Console.ReadLine());
            var medicoElegido = medicos.FirstOrDefault(m => m.Matricula == matriculaMedico);

            if (medicoElegido == null)
            {
                Console.WriteLine("Médico no válido. Finalizando...");
                return;
            }

            Console.WriteLine($"\n4. Disponibilidad del Dr/a. {medicoElegido.Apellido}:");
            
            var disponibilidadDelMedico = disponibilidadesEspecialidad
                .Where(d => d.Matricula == matriculaMedico)
                .ToList();

            foreach (var disp in disponibilidadDelMedico)
            {
                Console.WriteLine($"- Día de la semana {disp.DiaSemana}: de {disp.HoraInicio} a {disp.HoraFin}");
            }

            Console.Write("\nIngrese la fecha deseada para el turno (YYYY-MM-DD): ");
            string fechaDeseada = Console.ReadLine();
            
            Console.Write("Ingrese la hora deseada (HH:MM): ");
            string horaDeseada = Console.ReadLine();

            Console.WriteLine("\n5. RESUMEN DEL TURNO");
            Console.WriteLine("----------------------");
            Console.WriteLine($"Paciente: {paciente.Nombre} {paciente.Apellido}");
            Console.WriteLine($"Especialidad: {especialidadElegida.Nombre}");
            Console.WriteLine($"Médico: Dr/a. {medicoElegido.Apellido}");
            Console.WriteLine($"Fecha y Hora: {fechaDeseada} a las {horaDeseada}");
            Console.WriteLine("----------------------");
            
            Console.Write("\n¿Confirma la reserva de este turno? (S/N): ");
            if (Console.ReadLine()?.Trim().ToUpper() == "S")
            {
                var estadoReservado = context.Estados.FirstOrDefault(e => e.Descripcion == "reservado");

                var nuevoTurno = new Turno
                {
                    Dni = paciente.Dni,
                    Matricula = medicoElegido.Matricula,
                    IdEspecialidad = especialidadElegida.IdEspecialidad,
                    Fecha = fechaDeseada,
                    Hora = horaDeseada,
                    IdEstado = estadoReservado.IdEstado
                };

                context.Turnos.Add(nuevoTurno);
                context.SaveChanges();
                
                Console.WriteLine("\n>>> ¡Turno registrado exitosamente!");
            }
            else
            {
                Console.WriteLine("\n>>> Reserva cancelada por el usuario.");
            }
        }
    }
}