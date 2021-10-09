import { Button, TextField } from "@mui/material";
import { useEffect, useRef, useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import { patchMonster, saveMonster } from "../../state/actions/creationThunk";
import { monstersState } from "../../state/selectors/creationSelectors";
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
  const amountRef = useRef();

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

  const handleHeal = () => {
    let heal = amountRef.current.value;

    if (heal > 0) {
      let currentHP = monster.currentHitPoints;
      let maxHP = monster.hitPoints;

      currentHP += heal;
      if (currentHP > maxHP) currentHP = maxHP;

      dispatch(patchMonster({
        name: "currentHitPoints",
        value: currentHP.toString()
      }));

      amountRef.current.value = 0;
    }
  }

  const handleDamage = () => {
    let damage = amountRef.current.value;

    if (damage > 0) {
      let temporary = monster.temporaryHitPoints;
      let current = monster.currentHitPoints;

      if (temporary > 0) { // damage takes away from temporary hit points first
        if (temporary >= damage) {
          temporary -= damage;
          dispatch(patchMonster({
            name: "temporaryHitPoints",
            value: temporary.toString()
          }));
        } else {
          damage -= temporary;
          temporary = 0;
          dispatch(patchMonster({
            name: "temporaryHitPoints",
            value: temporary.toString()
          }));
          current -= damage;
          dispatch(patchMonster({
            name: "currentHitPoints",
            value: current.toString()
          }));
        }
      } else {
        current -= damage;
        dispatch(patchMonster({
          name: "currentHitPoints",
          value: current.toString()
        }));
      }
      amountRef.current.value = 0;
    }
  }

  return(
    <div className="char-sheet-row">

      <OptionMenu onSave={handleSave} cannotBeSaved={cannotBeSaved} unmountMe={() => unmountMe()} />

      <div className="first-char-sheet-column">
        <div className="name-field-div">
          <NameField
            nameRef={nameRef}
            name={"name"}
            value={valueOf("name")}
            cannotBeSaved={handleSaveButtonValidation}
          />
        </div>
        <div>
          <div className="padding-top">
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
      </div>
      <div>
        <div className="triple">
          <NumberField
            name={"challengeRating"}
            value={valueOf("challengeRating")}
            cannotBeSaved={handleSaveButtonValidation}
          />
          <NumberField
            disabled
            name={"proficiencyBonus"}
            value={valueOf("proficiencyBonus")}
            cannotBeSaved={handleSaveButtonValidation}
          />
          <Field
            notRequired
            name={"alignment"}
            value={valueOf("alignment")}
            cannotBeSaved={handleSaveButtonValidation}
          />
        </div>
        <div>
          <div className="padding-top">
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
      </div>
      <div>
        <div className="triple">
          <NumberField
            name={"armorClass"}
            value={valueOf("armorClass")}
            cannotBeSaved={handleSaveButtonValidation}
          />
          <NumberField
            name={"speed"}
            value={valueOf("speed")}
            cannotBeSaved={handleSaveButtonValidation}
          />
        </div>
        <div className="triple">
          <NumberField
            name={"currentArmorClass"}
            value={valueOf("currentArmorClass")}
            cannotBeSaved={handleSaveButtonValidation}
          />
          <NumberField
            name={"currentSpeed"}
            value={valueOf("currentSpeed")}
            cannotBeSaved={handleSaveButtonValidation}
          />
        </div>
        <div className="triple padding-top">
          <NumberField
            name={"hitPoints"}
            value={valueOf("hitPoints")}
            cannotBeSaved={handleSaveButtonValidation}
          />
          <NumberField
            name={"currentHitPoints"}
            value={valueOf("currentHitPoints")}
            cannotBeSaved={handleSaveButtonValidation}
          />
          <NumberField
            name={"temporaryHitPoints"}
            value={valueOf("temporaryHitPoints")}
            cannotBeSaved={handleSaveButtonValidation}
          />
        </div>
        <div className="heal-damage">
          <div className="heal">
            <Button variant="contained" className="heal" onClick={handleHeal}>
              Heal
            </Button>
          </div>
          <div className="amount">
            <TextField
              label="Amount"
              type="number"
              inputRef={amountRef}
            />
          </div>
          <div className="damage">
            <Button variant="contained" className="damage" onClick={handleDamage}>
              Damage
            </Button>
          </div>
        </div>
      </div>
    </div>
  );
};

export default CharacterSheet;