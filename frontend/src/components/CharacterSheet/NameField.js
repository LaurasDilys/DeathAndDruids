import { TextField, Tooltip } from "@mui/material";
import { useEffect, useState } from "react"
import { useDispatch, useSelector } from "react-redux";
import { patchMonster } from "../../state/actions/creationThunk";
import { creationState, monstersState } from "../../state/selectors/creationSelectors";
import field from '../Dictionaries/FieldNames.json';

const NameField = ({ nameRef, name, value, cannotBeSaved }) => {
  const { monster: thisMonster } = useSelector(creationState);
  const { monsters } = useSelector(monstersState);
  const [state, setState] = useState(value);
  const dispatch = useDispatch();

  // useEffect(() => {
  //   if (state === "" ||
  //     newAndNameNotUnique(state))
  //   {
  //     cannotBeSaved(name, true);
  //   }
  //   else
  //   {
  //     cannotBeSaved(name, false);
  //   }
  // }, []);

  useEffect(() => {
    if (state !== value) {
      setState(value);
    }
  }, [value])

  const newAndNameNotUnique = (targetValue) => {
    return monsters.filter(f => f.id !== thisMonster.sourceId).map(m => m.name).includes(targetValue);
  }

  const handleChange = event => {
    if (event.target.value === "" ||
      newAndNameNotUnique(event.target.value))
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

  return(
    <Tooltip title={newAndNameNotUnique(state) ? "This name is not unique" : ""}>
      <TextField
        inputRef={nameRef}
        error={state === "" || newAndNameNotUnique(state)}
        label={field[name]}
        value={state}
        // InputLabelProps={{
        //   shrink: true,
        // }}
        onChange={handleChange}
      />
    </Tooltip>
  );
};

export default NameField;