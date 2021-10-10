import { useDispatch, useSelector } from "react-redux";
import { combatState, monstersState } from "../../state/selectors";
import CombatantList from "./CombatantList";
import './Combat.css'
import { Fab } from "@mui/material";
import NavigateBeforeIcon from '@mui/icons-material/NavigateBefore';
import { useHistory  } from "react-router-dom";
import { useEffect } from "react";
import { getMonsters } from "../../state/actions/monstersThunk";
import { getCombatants } from "../../state/actions/combatThunk";

const Combat = () => {
  const { monsters } = useSelector(monstersState);
  const { combatants } = useSelector(combatState);
  const dispatch = useDispatch();
  let history = useHistory();

  useEffect(() => {
    dispatch(getCombatants());
    dispatch(getMonsters());
  }, [])

  return (
    <div className="combat-selection-row">
      <div className="combat-selection-col">
        {monsters.length === 0 ?
        // if there are no created monsters, user is redirected to Creation
        <Fab variant="extended" onClick={() => history.push('/creation')}>
          <NavigateBeforeIcon sx={{ mr: 1 }}/>
          Create some monsters first
        </Fab> : // else (there are created monsters)
        (combatants.length === 0 ?
        // if combat isn't in progress, user is asked to choose combatants
        <CombatantList /> :
        // if combatants are chosen, then CombatTabs are rendered
        <p>Combat</p>)}
      </div>
    </div>
  );
};

export default Combat;