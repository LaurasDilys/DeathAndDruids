import { Checkbox, FormControlLabel } from '@mui/material';
import { useEffect, useState } from "react"
import { useDispatch } from "react-redux";
import { patchMonster } from "../../state/actions/creationThunk";
import field from '../Dictionaries/FieldNames.json';

const SkillBlock = ({ name, value, proficiency, proficiencyName }) => {
  const [state, setState] = useState(proficiency);
  const dispatch = useDispatch();

  useEffect(() => {
    if (state !== proficiency) {
      setState(proficiency);
    }
  }, [proficiency])

  const handleChange = event => {
    setState(event.target.checked);
    
    dispatch(patchMonster({
      name: proficiencyName,
      value: event.target.checked ? "true" : "false"
    }));
  }

  return(
    <div>
      <FormControlLabel className="proficiency"
        control={<Checkbox
          checked={state}
          onChange={handleChange}
          color="default"
          // inputProps={{ 'aria-label': 'controlled' }}
        />}
        label={<>
          <span className="proficiency-span">{value}</span>
          <span>{name.includes("SavingThrow") ? "Saving Throw" : name/*field[name]*/}</span>
        </>}
      />
    </div>
  );

  // return(
  //   <>
  //     <p>{name}{value}{proficiency ? "true" : "false"}</p>

  //   </>
  // );
};

export default SkillBlock;