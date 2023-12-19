import { check, sleep } from "k6";
import http from "k6/http";

export let options = {
  // ... other options ...
  stages: [
    { duration: "30s", target: 20 },
    { duration: "40s", target: 20 },
    { duration: "30s", target: 0 }
  ],
  // ... other options ...
};

function getRandomInt(min, max) {
  return Math.floor(Math.random() * (max - min + 1) + min);
}

export default function() {
  let res = http.get("https://mybpcalcualator.azurewebsites.net/", {"responseType": "text"});
  check(res, {"is status 200": (r) => r.status === 200});

  // Corrected fields for form submission
  res = res.submitForm({
    fields: {
      "BP.Systolic": getRandomInt(70, 190).toString(),
      "BP.Diastolic": getRandomInt(40, 100).toString()
    }
  });

  check(res, {"is status 200": (r) => r.status === 200});
  sleep(3);
}

// Docker run instructions...