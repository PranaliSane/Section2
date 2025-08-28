import { createContext } from "react";
import CounterStore from "./CounterStore";
import { UiStores } from "./uiStores";

interface store {
    counterStore: CounterStore
    uiStore: UiStores
}

export const Store: store={
    counterStore: new CounterStore(),
    uiStore: new UiStores()
}

export const StoreContext = createContext(Store);