using AutoMapper;
using PhyndDemo_v2.Data;
using PhyndDemo_v2.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhyndDemo_v2.Managers
{
    public class ProgramManager : IProgramRepository
    {
        private readonly phynd2Context context;
        private readonly IMapper mapper;

        public ProgramManager(phynd2Context context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public IEnumerable<Models.Program> GetPrograms()
        {
            return context.Programs.ToList();
        }

        public Models.Program GetProgram(int Id)
        {
            return context.Programs.FirstOrDefault(a => a.Id == Id);
        }

        public void AddProgram(Models.Program program)
        {
            var newProgram = mapper.Map<Models.Program>(program);
            context.Programs.Add(newProgram);
            context.SaveChanges();
        }

        public void DeleteProgram(Models.Program program)
        {
            context.Programs.Remove(program);
            context.SaveChanges();
        }

        public void Update(Models.Program program, ProgramDTO newProgram)
        {
            var entity = mapper.Map<Models.Program>(newProgram);

            program.Name = entity.Name;
            program.Description = entity.Description;
            program.IsDeleted = entity.IsDeleted;
            program.CreatedOn = entity.CreatedOn;
            program.ModifiedBy = entity.ModifiedBy;
            program.IsDeleted = entity.IsDeleted;

            context.SaveChanges();
        }
    }
}
