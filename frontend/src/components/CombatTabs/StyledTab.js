import { Tab } from "@mui/material";
import { withStyles } from "@mui/styles";

const FadingTab = withStyles({
  root: {
    opacity: 0.5,
    '&:hover': {
      opacity: 1,
    },
    '&$selected': {
      opacity: 1,
    },
  },
  selected: {},
})(Tab); //props => <Tab {...props} />

const getColor = hpRation => {

  let color;

  switch (true) {
    case (hpRation < 0.1): color = "#ab2121"; break; //FireBrick 40%
    case (hpRation < 0.2): color = "#cc7000"; break; //DarkOrange 40%
    case (hpRation < 0.4): color = "#ccad00"; break; //Gold 40%
    case (hpRation < 0.6): color = "#8ab92d"; break; //YellowGreen 45%
    case (hpRation < 0.8): color = "#28a428"; break; //ForestGreen 40%
    default: color = "Green"; //25%
  }

  return({
    color: color
  })
}

export { FadingTab, getColor }