import { TextField } from "@mui/material";
import { useEffect, useState } from "react"
import { useDispatch } from "react-redux";
import { patchMonster } from "../../state/actions/creationThunk";
import field from '../../dictionaries/FieldNames.json';
import { patchCombatant } from "../../state/actions/combatThunk";

const Field = ({ id, name, value, cannotBeSaved, notRequired, multiline }) => {
  const [state, setState] = useState(value);
  const dispatch = useDispatch();

  useEffect(() => {
    if (state !== value) {
      setState(value);
    }
  }, [value])

  const handleChange = event => {
    if (event.target.value === "") {
      cannotBeSaved(name, true);
    } else {
      cannotBeSaved(name, false);
    }

    setState(event.target.value);
    
    if (id) {
      dispatch(patchCombatant({
        id: id,
        name: name,
        value: event.target.value
      }));
    } else {
      dispatch(patchMonster({
        name: name,
        value: event.target.value
      }));
    }
  }

  return(
    <TextField
      error={!notRequired && state === ""}
      label={field[name]}
      value={state}
      onChange={handleChange}
      multiline={multiline}
      rows={multiline && 10}
      fullWidth={multiline}
    />
  );
};

export default Field;