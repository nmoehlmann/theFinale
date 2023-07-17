import { AppState } from "../AppState.js"
import { VaultKeep } from "../models/Keep.js"
import { api } from "./AxiosService.js"

class VaultKeepsService {
  async createVaultKeep(vkData) {
    const res = await api.post(`api/vaultKeeps`, vkData)
    AppState.keepsInVault.push(new VaultKeep(res.data))
  }
}

export const vaultKeepsService = new VaultKeepsService()