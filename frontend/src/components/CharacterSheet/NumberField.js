import { TextField } from "@mui/material";
import { useEffect, useState } from "react"
import { useDispatch } from "react-redux";
import { patchMonster } from "../../state/actions/creationThunk";
import { getMonsters } from "../../state/actions/monstersThunk";
import field from '../../domain/FieldNames.json';

const NumberField = ({ name, value }) => {
  const [state, setState] = useState(value);
  const dispatch = useDispatch();

  useEffect(() => {
    if (state !== value) {
      setState(value);
    }
  }, [value])

  const handleChange = event => {
    setState(event.target.value);
    dispatch(patchMonster({
      name: name,
      value: event.target.value
    }));
    dispatch(getMonsters()); // update saved monsters after every patch
  }

  return(
    <TextField
      error={state === ""}
      label={field[name]}
      value={state}
      type="number"
      InputLabelProps={{
        shrink: true,
      }}
      onChange={handleChange}
    />
  );
};

export default NumberField;