using Business.Interfaces;
using Business.Models;
using Data.Repositories;

namespace Application.Services
{
    public class PatchService
    {
        private readonly CombatRepository _combatRepository;
        private readonly CreationRepository _creationRepository;
        private readonly MapperService _mapper;

        public PatchService(CombatRepository combatRepository,
            CreationRepository creationRepository,
            MapperService mapper)
        {
            _combatRepository = combatRepository;
            _creationRepository = creationRepository;
            _mapper = mapper;
        }

        public bool PatchCreation(ICreationPatchRequest patch)
        {
            var creation = _creationRepository.GetOpened();
            if (creation == null) return false;

            var creature = new Creature();
            _mapper.TransformIntoExpanded(creature, creation);
            if (_mapper.Patch(creature, patch))
            {
                _mapper.TransformIntoFlat(creation, creature);

                creation.Saved = false;

                _creationRepository.SaveChanges();

                return true;
            }
            return false; // bad patch request
        }

        public bool PatchCombatant(ICombatantPatchRequest patch)
        {
            var combatant = _combatRepository.Get(patch.Id);
            if (combatant == null) return false;

            var creature = new Creature();
            _mapper.TransformIntoExpanded(creature, combatant);
            if (_mapper.Patch(creature, patch as ICreationPatchRequest))
            {
                _mapper.TransformIntoFlat(combatant, creature);

                _combatRepository.SaveChanges();

                return true;
            }
            return false; // bad patch request
        }
    }
}
