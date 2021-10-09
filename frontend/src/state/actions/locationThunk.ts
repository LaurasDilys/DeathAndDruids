import API from "../../domain/Api";

export const setRoute = (routeChangeRequest) => (dispatch) => {
  API.put("location/route", routeChangeRequest)
    .catch(err => console.log(err));
}

export const setSelectedTab = (tabChangeRequest) => (dispatch) => {
  API.put("location/selectedTab", tabChangeRequest)
    .catch(err => console.log(err));
}