import { useSelector } from "react-redux";
import { monstersState } from "../../state/selectors";
import CombatantList from "./CombatantList";
import './Combat.css'
import { Fab } from "@mui/material";
import NavigateBeforeIcon from '@mui/icons-material/NavigateBefore';
import { useHistory  } from "react-router-dom";

const Combat = () => {
  const { monsters } = useSelector(monstersState);
  let history = useHistory();

  return (
    <div className="combat-selection-row">
      <div className="combat-selection-col">
        {monsters.length > 0 ? <CombatantList /> :
        <Fab variant="extended" onClick={() => history.push('/creation')}>
          <NavigateBeforeIcon sx={{ mr: 1 }}/>
          Create some monsters first
        </Fab>}
      </div>
    </div>
  );
};

export default Combat;