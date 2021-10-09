import { Button } from "@mui/material";
import { useEffect, useRef, useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import { getOpenedMonster, saveMonster } from "../../state/actions/creationThunk";
import { getMonsters } from "../../state/actions/monstersThunk";
import { monstersState } from "../../state/selectors/creationSelectors";
import CheckBox from "./CheckBox";
import NameField from "./NameField";
import NumberField from "./NumberField";
import AbilityBlock from "./AbilityBlock";
import SkillBlock from "./SkillBlock";
import tree from '../../dictionaries/AbilityTree.json';
import OptionMenu from "./OptionMenu";
import Field from "./Field";

const CharacterSheet = ({ monster, unmountMe }) => {
  const [cannotBeSaved, setCannotBeSaved] = useState([]);
  const { monsters } = useSelector(monstersState);
  const dispatch = useDispatch();
  const nameRef = useRef();

  useEffect(() => { // on first render or page refresh
    const name = nameRef.current.value;
    if (name === "" ||
      monsters.filter(f => f.id !== monster.sourceId).map(m => m.name).includes(name))
    {
      setCannotBeSaved([...cannotBeSaved, "name"]);
    }
  }, []);
  
  const mapped = obj => {
    let array = [];
    let keys = Object.keys(obj);
    let values = Object.values(obj);

    for (let i = 0; i < keys.length; i++) {
      const monsterPropertyAsNameAndValue = {
        name : keys[i],
        value : values[i]
      }
      array.push(monsterPropertyAsNameAndValue)
    }
    return array;
  }

  const valueOf = name => {
    return mapped(monster).find(x => x.name === name).value;
  }

  const handleSave = () => {
    if (monster.saved) {
      alert("No changes have been made");
    }
    else {
      dispatch(saveMonster());
    }
  }

  const handleSaveButtonValidation = (field, bool) => {
    if (bool) setCannotBeSaved([...cannotBeSaved, field]);
    else setCannotBeSaved(cannotBeSaved.filter(x => x !== field));
    // console.log(`${field} cannot be saved: ${bool}`);
  }

  return(
    <div className="char-sheet-row">
      <OptionMenu onSave={handleSave} cannotBeSaved={cannotBeSaved} unmountMe={() => unmountMe()} />

      <div className="char-sheet-col">




        <div className="name-field-div">
          <NameField
            nameRef={nameRef}
            name={"name"}
            value={valueOf("name")}
            cannotBeSaved={handleSaveButtonValidation}
          />
        </div>

        <div>
          {Object.keys(tree).slice(0, 3).map((ability, index) => <AbilityBlock
            key={index}
            name={ability}
            value={valueOf(ability)}
            modifierValue={valueOf(tree[ability]["modifier"])}
            cannotBeSaved={handleSaveButtonValidation}
          >
            {tree[ability]["skills"].map((skill, index) => <SkillBlock
              key={index}
              name={skill[0]}
              value={valueOf(skill[0])}
              proficiency={valueOf(skill[1])}
              proficiencyName={skill[1]}
            /> )}
          </AbilityBlock> )}
        </div>
      </div>

      <div className="char-sheet-col">


        
        <div className="triple">
          <NumberField
            name={"CR"}
            value={valueOf("challengeRating")}
            cannotBeSaved={handleSaveButtonValidation}
          />
          <NumberField
            disabled
            name={"Prof"}
            value={valueOf("proficiencyBonus")}
            cannotBeSaved={handleSaveButtonValidation}
          />
          <Field
            name={"Align"}
            value={valueOf("challengeRating")}
            cannotBeSaved={handleSaveButtonValidation}
          />
        </div>

        <div>
          {Object.keys(tree).slice(3, 6).map((ability, index) => <AbilityBlock
            key={index}
            name={ability}
            value={valueOf(ability)}
            modifierValue={valueOf(tree[ability]["modifier"])}
            cannotBeSaved={handleSaveButtonValidation}
          >
            {tree[ability]["skills"].map((skill, index) => <SkillBlock
              key={index}
              name={skill[0]}
              value={valueOf(skill[0])}
              proficiency={valueOf(skill[1])}
              proficiencyName={skill[1]}
            /> )}
          </AbilityBlock> )}
        </div>


        

          
          
        </div>


        <div className="char-sheet-col">


        <div className="triple">
          <NumberField
            name={"AC"}
            value={valueOf("armorClass")}
            cannotBeSaved={handleSaveButtonValidation}
          />
          <NumberField
            disabled
            name={"Speed"}
            value={valueOf("speed")}
            cannotBeSaved={handleSaveButtonValidation}
          />
        </div>

        <div className="triple">
          <NumberField
            name={"Current"}
            value={valueOf("currentArmorClass")}
            cannotBeSaved={handleSaveButtonValidation}
          />
          <NumberField
            disabled
            name={"Current"}
            value={valueOf("currentSpeed")}
            cannotBeSaved={handleSaveButtonValidation}
          />
        </div>


      


      </div>
    </div>
  );
};

export default CharacterSheet;