import { TextField, Tooltip } from "@mui/material";
import { useEffect, useState } from "react"
import { useDispatch, useSelector } from "react-redux";
import { patchMonster } from "../../state/actions/monstersThunk";
import { creationState, monstersState } from "../../state/selectors";
import field from '../../dictionaries/FieldNames.json';

const CombatNameField = ({ name, value }) => {
  const { monster: thisMonster } = useSelector(creationState);
  const { monsters } = useSelector(monstersState);
  const [state, setState] = useState(value);
  const dispatch = useDispatch();

  useEffect(() => {
    if (state !== value) {
      setState(value);
    }
  }, [value])

  return(
    <TextField
      disabled
      label={field[name]}
      value={name}
    />
  );
};

export default CombatNameField;