import { useSelector } from "react-redux";
import { monstersState } from "../../state/selectors";
import CombatantList from "./CombatantList";
import './Combat.css'

const Combat = () => {
  const { monsters } = useSelector(monstersState);

  return (
    <div className="combat-selection-row">
      <div className="combat-selection-col">
        {monsters.length > 0 ? <CombatantList /> :
        <p>Create some monsters</p>}
      </div>
    </div>
  );
};

export default Combat;