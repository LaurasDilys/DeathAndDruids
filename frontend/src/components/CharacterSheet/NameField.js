import { TextField, Tooltip } from "@mui/material";
import { useEffect, useState } from "react"
import { useDispatch, useSelector } from "react-redux";
import { patchMonster } from "../../state/actions/creationThunk";
import { getMonsters } from "../../state/actions/monstersThunk";
import field from '../../domain/FieldNames.json';
import { monstersState } from "../../state/selectors/creationSelectors";

const NameField = ({ sourceId, name, value, cannotBeSaved }) => {
  const { monsters } = useSelector(monstersState);
  const [state, setState] = useState(value);
  const dispatch = useDispatch();

  useEffect(() => {
    if (state !== value) {
      setState(value);
    }
  }, [value])

  const handleChange = event => {
    if (event.target.value === "" ||
      monsters.filter(f => f.id !== sourceId).map(m => m.name).includes(event.target.value))
    {
      cannotBeSaved(name, true);
    }
    else
    {
      cannotBeSaved(name, false);
    }

    setState(event.target.value);

    dispatch(patchMonster({
      name: name,
      value: event.target.value
    }));
  }

  const newAndNameNotUnique = () => {
    return monsters.filter(f => f.id !== sourceId).map(m => m.name).includes(state);
  }

  return(
    <Tooltip title={newAndNameNotUnique() ? "This name is not unique" : ""}>
      <TextField
        error={state === "" || newAndNameNotUnique()}
        label={field[name]}
        value={state}
        InputLabelProps={{
          shrink: true,
        }}
        onChange={handleChange}
      />
    </Tooltip>
  );
};

export default NameField;