﻿using Microsoft.EntityFrameworkCore;
using SistemaDeRecarga.Context;
using SistemaDeRecarga.Model;

namespace SistemaDeRecarga.Repository
{
    public class EstudantesRepository : IEstudantesRepository
    {
        private readonly AppDbContext _context;

        public EstudantesRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Estudantes>> GetAllEstudantesAsync()
        {
            return await _context.Estudantes.ToListAsync();
        }

        public async Task<Estudantes> GetEstudantesByIdAsync(int id)
        {
            return await _context.Estudantes.FindAsync(id);
        }

        public async Task CreateEstudantesAsync(Estudantes estudante)
        {
            await _context.Estudantes.AddAsync(estudante);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEstudantesAsync(Estudantes estudante)
        {
            _context.Estudantes.Update(estudante);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEstudantesAsync(int id)
        {
            var estudantes = await _context.Estudantes.FindAsync(id);

            if (estudantes != null)
            {
                _context.Estudantes.Remove(estudantes);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<int> GetLastIdAsync()
        {
            // Verificar se a tabela está vazia
            if (!await _context.Estudantes.AnyAsync())
            {
                return 0;
            }

            // Encontrar o maior ID existente no banco de dados
            return await _context.Estudantes.MaxAsync(x => x.Id);
        }

        public async Task<bool> EmailAndRegistrationNumberExistAsync(string email, string matricula) //Verifica a existencia de um email ou matrícula no banco
        {
            return await _context.Estudantes.AnyAsync(x => x.Email == email || x.RegistrationNumber == matricula);
        }
    }
}
