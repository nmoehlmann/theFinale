import { AppState } from "../AppState.js"
import { Keep, VaultKeep } from "../models/Keep.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class KeepsService{
  async createKeep(keepData) {
    const res = await api.post('api/keeps', keepData)
    logger.log(res.data, 'keeps res.data')
    AppState.keeps.push(new Keep(res.data))
    AppState.userKeeps.push(new Keep(res.data))
    logger.log(AppState.keeps, 'keeps appstate')
  }

  async getAllKeeps(){
    const res = await api.get('api/keeps')
    logger.log(res.data, 'get res.data')
    AppState.keeps = res.data.map(k => new Keep(k))
    logger.log('keeps appstate', AppState.keeps)
  }

  async getKeepById(keepId, vkId){
    // debugger
    const res = await api.get(`api/keeps/${keepId}`)
    AppState.activeKeep = new VaultKeep(res.data)
    AppState.activeKeep.vaultKeepId = vkId
    logger.log(AppState.activeKeep)
  }

  async getUserKeeps(userId) {
    const res = await api.get(`api/profiles/${userId}/keeps`)
    logger.log(res.data)
    AppState.userKeeps = res.data.map(k => new Keep(k))
    logger.log(AppState.userKeeps)
  }

  async deleteKeep(keepId) {
    await api.delete(`api/keeps/${keepId}`)
    AppState.keeps = AppState.keeps.filter(k => k.id != keepId)
    logger.log("filtered keeps appstate", AppState.keeps)
    AppState.userKeeps = AppState.userKeeps.filter(k => k.id != keepId)
    logger.log("filtered users keeps appstate", AppState.userKeeps)
  }

  async updateKeep(keepId, updateData) {
    const res = await api.put(`api/keeps/${keepId}`, updateData)
    AppState.activeKeep = new Keep(res.data)
    logger.log('updated keep', AppState.activeKeep)
  }


}

export const keepsService = new KeepsService()