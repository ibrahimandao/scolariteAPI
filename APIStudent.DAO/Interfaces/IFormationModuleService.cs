﻿using APIStudent.Model;

namespace APIStudent.DAO.Interfaces
{
    public interface IFormationModuleService
    {
        public void add(FormationModule formationModule);

        public void remove(int id);

        public IEnumerable<Module> getModulesByFormationId(int formationid);

        //public IEnumerable<FormationModule> getModulesByFormationId(int formationid);
    }
}
