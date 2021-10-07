import { Checkbox, FormControlLabel } from '@mui/material';
import { useEffect, useState } from "react"
import { useDispatch } from "react-redux";
import { patchMonster } from "../../state/actions/creationThunk";
import field from '../Dictionaries/FieldNames.json';

const CheckBox = ({ name, value }) => {
  const [state, setState] = useState(value);
  const dispatch = useDispatch();

  useEffect(() => {
    if (state !== value) {
      setState(value);
    }
  }, [value])

  const handleChange = event => {
    setState(event.target.checked);
    
    dispatch(patchMonster({
      name: name,
      value: event.target.checked ? "true" : "false"
    }));
  }

  return(
    <FormControlLabel
      label={name} // field[name]
      control={<Checkbox
        checked={state}
        onChange={handleChange}
        color="default"
        // inputProps={{ 'aria-label': 'controlled' }}
      />}
    />
  );
};

export default CheckBox;