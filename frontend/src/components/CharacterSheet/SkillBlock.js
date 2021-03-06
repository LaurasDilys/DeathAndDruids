import { Checkbox, FormControlLabel } from '@mui/material';
import { useEffect, useState } from "react"
import { useDispatch } from "react-redux";
import { patchMonster } from "../../state/actions/creationThunk";
import field from '../../dictionaries/FieldNames.json';
import { patchCombatant } from '../../state/actions/combatThunk';

const SkillBlock = ({ id, name, value, proficiency, proficiencyName }) => {
  const [state, setState] = useState(proficiency);
  const dispatch = useDispatch();

  useEffect(() => {
    if (state !== proficiency) {
      setState(proficiency);
    }
  }, [proficiency])

  const handleChange = event => {
    setState(event.target.checked);
    
    if (id) {
      dispatch(patchCombatant({
        id: id,
        name: proficiencyName,
        value: event.target.checked ? "true" : "false"
      }));
    } else {
      dispatch(patchMonster({
        name: proficiencyName,
        value: event.target.checked ? "true" : "false"
      }));
    }
  }

  return(
    <div>
      <FormControlLabel className="proficiency"
        control={<Checkbox
          checked={state}
          onChange={handleChange}
          color="default"
          style={{ transform: "scale(0.8)" }}
          // inputProps={{ 'aria-label': 'controlled' }}
        />}
        label={<>
          <span className="proficiency-span">{value}</span>
          <span>{name.includes("SavingThrow") ? "Saving Throw" : field[name]}</span>
        </>}
      />
    </div>
  );
};

export default SkillBlock;