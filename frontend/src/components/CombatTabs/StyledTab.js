import { Tab } from "@mui/material";
import { withStyles } from "@mui/styles";

const StyledTab = withStyles({
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
})(props => <Tab {...props} />);

const getColor = hpRation => {

  let color;

  switch (true) {
    case (hpRation < 0.1): color = "FireBrick"; break;
    case (hpRation < 0.2): color = "#e67e00"; break; //darker dark orange
    case (hpRation < 0.4): color = "#e6c300"; break; //darker gold
    case (hpRation < 0.6): color = "YellowGreen"; break;
    case (hpRation < 0.8): color = "#2db92d"; break; //forest green ??
    default: color = "Green";
  }

  return({
    color: color
  })
}

export { StyledTab, getColor }