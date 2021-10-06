import { TextField } from "@mui/material";
import { useEffect, useState } from "react"
import { useDispatch } from "react-redux";
import { patchMonster } from "../../state/actions/creationThunk";
import field from '../../domain/FieldNames.json';

const NumberField = ({ name, value, cannotBeSaved }) => {
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
    
    dispatch(patchMonster({
      name: name,
      value: event.target.value
    }));
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