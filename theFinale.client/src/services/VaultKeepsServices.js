import { AppState } from "../AppState.js"
import { VaultKeep } from "../models/Keep.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class VaultKeepsService {
  async createVaultKeep(vkData) {
    const res = await api.post(`api/vaultKeeps`, vkData)
    AppState.keepsInVault.push(new VaultKeep(res.data))
    AppState.activeKeep.kept++
  }

  async getVaultKeeps(vaultId) {
    const res = await api.get(`api/vaults/${vaultId}/keeps`)
    AppState.keepsInVault = res.data.map(vk => new VaultKeep(vk))
    logger.log('keeps in vault', AppState.keepsInVault)
  }

  async deleteVaultKeep(vkId) {
    await api.delete(`api/vaultKeeps/${vkId}`)
    const foundIndex = AppState.keepsInVault.findIndex(vk => vk.vaultKeepId == vkId)
    AppState.keepsInVault.splice(foundIndex, 1)
  }
}

export const vaultKeepsService = new VaultKeepsService()