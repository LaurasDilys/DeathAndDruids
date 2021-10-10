import API from "../../domain/Api";
import { getSelectedTabAction } from "./locationActions";

export const setRoute = (routeChangeRequest) => (dispatch) => {
  API.put("location/route", routeChangeRequest)
    .catch(err => console.log(err));
}

export const setSelectedTab = (id) => (dispatch) => {
  API.put("location/selectedTab", { selectedTab: id } )
    .then(() => getSelectedTabAction({ selectedTab: id }))
    .catch(err => console.log(err));
}

export const getSelectedTab = () => (dispatch) => {
  API.get("location/selectedTab")
    .then((res) => getSelectedTabAction(res.data))
    .catch(err => console.log(err));
}