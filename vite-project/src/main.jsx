import React from "react"
import ReactDOM from "react-dom/client"
import "./index.css"

import { Provider } from "react-redux"
import store from "./redux/store.js"

import { Router } from "./Router.jsx"

ReactDOM.createRoot(document.getElementById("root")).render(
	<React.StrictMode>
		<Provider store={store}>
			<Router />
		</Provider>
	</React.StrictMode>
)
