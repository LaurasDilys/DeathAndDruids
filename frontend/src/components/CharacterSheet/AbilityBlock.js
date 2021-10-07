import { TextField } from "@mui/material";
import { useEffect, useState } from "react"
import { useDispatch } from "react-redux";
import { patchMonster } from "../../state/actions/creationThunk";
import "./CharacterSheet.css"

const AbilityBlock = ({ name, value, modifierValue, cannotBeSaved, children }) => {
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
    <div className="ability-block">
      <div className="ability">
        <TextField
          error={state === ""}
          label={name.charAt(0).toUpperCase() + name.slice(1)}
          value={state}
          type="number"
          // InputLabelProps={{
          //   shrink: true,
          // }}
          onChange={handleChange}
        />
        <TextField
          disabled
          value={modifierValue}
        />
      </div>
      <div className="skills">
        {children}
      </div>
    </div>
  );
};

export default AbilityBlock;